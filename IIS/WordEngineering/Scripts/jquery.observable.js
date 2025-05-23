﻿/*! jsObservable: http://github.com/BorisMoore/jsviews */
/*
* Subcomponent of JsViews
* Data change events for data linking
*
* Copyright 2011, Boris Moore and Brad Olenick
* Released under the MIT License.
*/
(function ($, undefined) {
    $.observable = function (data, options) {
        return $.isArray(data)
			? new ArrayObservable(data)
			: new ObjectObservable(data);
    };

    var splice = [].splice;

    function ObjectObservable(data) {
        if (!this.data) {
            return new ObjectObservable(data);
        }

        this._data = data;
        return this;
    };

    $.observable.Object = ObjectObservable;

    ObjectObservable.prototype = {
        _data: null,

        data: function () {
            return this._data;
        },

        setProperty: function (path, value) { // TODO in the case of multiple changes (object): raise single propertyChanges event (which may span different objects, via paths) with set of changes.
            if ($.isArray(path)) {
                // This is the array format generated by serializeArray. However, this has the problem that it coerces types to string,
                // and does not provide simple support of convertTo and convertFrom functions.
                // TODO: We've discussed an "objectchange" event to capture all N property updates here. See TODO note above about propertyChanges.
                for (var i = 0, l = path.length; i < l; i++) {
                    var pair = path[i];
                    this.setProperty(pair.name, pair.value);
                }
            } else
                if (typeof (path) === "object") {
                    // Object representation where property name is path and property value is value.
                    // TODO: We've discussed an "objectchange" event to capture all N property updates here. See TODO note above about propertyChanges.
                    for (var key in path) {
                        this.setProperty(key, path[key]);
                    }
                } else {
                    // Simple single property case.
                    var setter, property,
					object = this._data,
					leaf = getLeafObject(object, path);

                    path = leaf[1];
                    leaf = leaf[0];
                    if (leaf) {
                        property = leaf[path];
                        if ($.isFunction(property)) {
                            // Case of property setter/getter - with convention that property() is getter and property( value ) is setter
                            setter = property;
                            property = property.call(leaf); //get
                        }
                        if (property != value) { // test for non-strict equality, since serializeArray, and form-based editors can map numbers to strings, etc.
                            if (setter) {
                                setter.call(leaf, value); 	//set
                                value = setter.call(leaf); //get updated value
                            } else {
                                leaf[path] = value;
                            }
                            $(leaf).triggerHandler("propertyChange", { path: path, value: value, oldValue: property });
                        }
                    }
                }
            return this;
        }
    };

    function getLeafObject(object, path) {
        if (object && path) {
            var parts = path.split(".");

            path = parts.pop();
            while (object && parts.length) {
                object = object[parts.shift()];
            }
            return [object, path];
        }
        return [];
    };

    function ArrayObservable(data) {
        if (!this.data) {
            return new ArrayObservable(data);
        }

        this._data = data;
        return this;
    };

    function triggerArrayEvent(array, eventArgs) {
        $([array]).triggerHandler("arrayChange", eventArgs);
    };

    function validateIndex(index) {
        if (typeof index !== "number") {
            throw "Invalid index.";
        }
    };

    $.observable.Array = ArrayObservable;

    ArrayObservable.prototype = {
        _data: null,

        data: function () {
            return this._data;
        },

        insert: function (index, data) {
            validateIndex(index);

            if (arguments.length > 1) {
                data = $.isArray(data) ? data : [data];  // TODO: Clone array here?
                // data can be a single item (including a null/undefined value) or an array of items.

                if (data.length > 0) {
                    splice.apply(this._data, [index, 0].concat(data));
                    triggerArrayEvent(this._data, { change: "insert", index: index, items: data });
                }
            }
            return this;
        },

        remove: function (index, numToRemove) {
            validateIndex(index);

            numToRemove = (numToRemove === undefined || numToRemove === null) ? 1 : numToRemove;
            if (numToRemove && index > -1) {
                var items = this._data.slice(index, index + numToRemove);
                numToRemove = items.length;
                if (numToRemove) {
                    this._data.splice(index, numToRemove);
                    triggerArrayEvent(this._data, { change: "remove", index: index, items: items });
                }
            }
            return this;
        },

        move: function (oldIndex, newIndex, numToMove) {
            validateIndex(oldIndex);
            validateIndex(newIndex);

            numToMove = (numToMove === undefined || numToMove === null) ? 1 : numToMove;
            if (numToMove) {
                var items = this._data.slice(oldIndex, oldIndex + numToMove);
                this._data.splice(oldIndex, numToMove);
                this._data.splice.apply(this._data, [newIndex, 0].concat(items));
                triggerArrayEvent(this._data, { change: "move", oldIndex: oldIndex, index: newIndex, items: items });
            }
            return this;
        },

        refresh: function (newItems) {
            var oldItems = this._data.slice(0);
            splice.apply(this._data, [0, this._data.length].concat(newItems));
            triggerArrayEvent(this._data, { change: "refresh", oldItems: oldItems });
            return this;
        }
    };
})(jQuery);