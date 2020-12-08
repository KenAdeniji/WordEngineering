 /**
 * https://www.ibm.com/developerworks/community/wikis/home?lang=en#!/wiki/W65fd19fc117a_4d18_87e4_5f7b8a6727cc/page/JavaScript%20Functions?section=Get%20Week%20Number%20From%20Date
 * Java Script functions written by Christopher Dawes of IBM.  You are free to use and modify these functions for your own applications.
 * I do not claim in any way that they are defect free, it is my expectation that you will sufficiently test the function within your
 * application before using them in any production scenario.
 *
 * If you do encounter any issues please report them via the Dev Works Forum -> https://www.ibm.com/developerworks/community/groups/service/html/communityview?communityUuid=05651788-f17f-4309-a5c6-698e67acd9c1#fullpageWidgetId%3DW10cc963850cf_40f3_89ff_2bf2c4101574
 */

/*
* Will sort the options of the item passed to it.
* Must pass it the UI item reference.  If called from in the list object you can use "item",
* otherwise would have to use "page.F_DropDown" or "form.getPage('P_Page').F_DropDown"
*
* Will keep track of the currently selected value and insure that it is re-selected after the list is sorted
*/
app.getSharedData().sortList = function(theItem)
{
    //store the current value
    var value = theItem.getBOAttr().getValue();

     //sort the list
     var options = theItem.getOptions();

     if(options !== null) {
       options.sort(function(a,b) {
         return get(a, 'title').localeCompare(get(b, 'title'));
       });

       theItem.setOptions(options);

       //reset back to the current value
       theItem.getBOAttr().getValue(value);
     }
}

/*
* Returns the number of working dates between the two dates.
* includeWeekends - Pass true if you want to include weekends otherwise false.
*/
app.getSharedData().workingDaysBetweenDates = function(startDt, endDt, includeWeekends) {
    // Validate input
    if (endDt < startDt)
        return 0;

    // Calculate days between dates
    var millisecondsPerDay = 86400 * 1000; // Day in milliseconds
    startDt.setHours(0,0,0,1);  // Start just after midnight
    endDt.setHours(23,59,59,999);  // End just before midnight
    var diff = endDt.getTime() - startDt.getTime();  // Milliseconds between datetime objects   
    var days = Math.ceil(diff / millisecondsPerDay);   

    if(!includeWeekends) {
        // Subtract two weekend days for every week in between
        var weeks = Math.floor(days / 7);
        var days = days - (weeks * 2);

        // Handle special cases
        var startDay = startDt.getDay();
        var endDay = endDt.getDay();

        // Remove weekend not previously removed.  
        if (startDay - endDay > 1)        
            days = days - 2;     


        // Remove start day if span starts on Sunday but ends before Saturday
        if (startDay === 0 && endDay !== 6)
            days = days - 1  

        // Remove end day if span ends on Saturday but starts after Sunday
       if (endDay === 6 && startDay !== 0)
           days = days - 1  

    }

    return days;
}

/*
* Returns the number of hours from the two times provided
* startTime - Can be date, time or dateTime
* endTime - Can be date, time or dateTime
* rndHours - Round the result to the highest integer (hour). Values are true or false.
*/
app.getSharedData().calcDuration = function(startTime, endTime, rndHours) {
  
  //convert to milliseconds
  var d1 = startTime.getTime();
  var d2 = endTime.getTime();
  
  var diff = d2 - d1;
 
  var durHours = diff / 1000 / 60 / 60;
 
  if(rndHours) {
    Math.ceil(durHours);
  }
    
  return durHours;
}

/*
* Given the BO of a date field this function will validate that the entered date is
* after today.
* dateObj1 - the business object of the date field (i.e. BOA, BO.F_Date1)
* errorMsg - The message to display to the user when the field is set to invalid
*/
app.getSharedData().isDateAfterToday = function(dateObj1, errorMsg) {

    var today = new Date();       //get todays date, including the current time

    var d = dateObj1.getValue(); //get date from passed object
    //set the time of the date to just before midnight

    d.setSeconds(59);
    d.setMinutes(59);
    d.setHours(23);

    //D1 MUST be less then today
    if(d < today) {
          dateObj1.setValid(false, errorMsg);
    } else {
      dateObj1.setValid(true, "");
    }
}

/*
* Given two date fields the function will validate that they are numOfDays apart.
* If the dateObj2 is not numOfDays greater than dateObj1 then dateObj2 will be set
* invalid with the specified errorMsg.
*
* dateObj1 - the first date field (e.g. BO.F_Date1)
* dateObj2 - the second date field (e.g. BO.F_Date2)
* numOfDays - the number of days that D2 must be grater than D1
* errorMsg - The error message to display for D2 when invalid
*
* Usage: Place function in the Settings...onStart
* Call the function in the onItemChange of the two date fields:
* app.getSharedData().compareDatesByDays(BO.F_Date2, BO.F_Date3, 14, "The date must be 14 days past D1.");
*/
app.getSharedData().compareDatesByDays = function(dateObj1, dateObj2, numOfDays, errorMsg) {
 
var d1 = dateObj1.getValue(); //get first date
var d2 = dateObj2.getValue(); //get sec date
var diff = 0;
 
//convert to milliseconds
var d1_milli = d1.getTime();
var d2_milli = d2.getTime();
 
//get difference and convert back to days
var diff_milli = d2_milli - d1_milli;
var nDays = Math.ceil(diff_milli / 1000 / 60 / 60 / 24);
 
  //if the diff is less then numOfDays set the d2 field invalid
  if(nDays < numOfDays) {
    dateObj2.setValid(false, errorMsg);
  } else {
    dateObj2.setValid(true, "");
  }
}

app.getSharedData().removeDuplicatesFromList = function(theList) {
    var newList = new Array();
    //loop through the current list
  for(var j=0; j<theList.length;j++) {

      var curItem = get(theList, j);
      var itemFound = false;
      //loop through the newList checking to see if the item is there
      for(var k=0; k<newList.length;k++) {
        if(get(curItem, 'title') === get(get(newList, k), 'title')) {
         itemFound = true;
        break;
        }
      } 
      if(!itemFound) {
          newList.push(curItem);
      }
  }
  return newList;
}

/*
* Removes the blank option from the list even if it is not the first,
* will also remove any duplicate blank options
*
* theList - the List item from which to remove blank options
*
* returns a new list with no blank options
*/
app.getSharedData().removeBlankFromList = function(theList) {

  //check all options for a blank value and remove it...

  var newList = new Array();

  //loop through the current list

  for(var j=0; j<theList.length;j++) {

      var curItem = get(theList, j);

      if(curItem !== "") {

          newList.push(curItem);

      }

  }

  return newList;

}

/* check to see if entry exists in the table, this will check all rows and columns. 
* table: This is the actual table object, not the string ID (e.g. BO.F_Table)
* entry: this is the value of what you want to search for, the content of the table column will be converted to a string
* usage: This is usually called within the onClick of a button that adds rows to a table.  Or you might want to search to see if a record exists in the table.
*   if(!app.getSharedData().checkTableForEntry(BO.F_Table, theSearchValue)) {
*          . . .
*   }
*/app.getSharedData().checkTableForEntry = function(table, entry) {
  var entryFound = false;
  for(var i = 0; i < table.getLength(); i++) {
      var row = table.get(i);
      var tmpentry = entry;

      //loop through all the columns of the source table
      var cols = row.getChildren();
      for(var j=0;j<cols.getLength();j++) {
          var c = cols.get(j).getValue();

          //Convert to string for comparison

          if (cols.get(j).getType() !== "string") {
              c = c.toString();
           }

          if(c === tmpentry) {
            entryFound = true;
            break;
          }
        } //inner for 
      } //outer for
  return entryFound;
}

/* check to see if entry exists in the table, checks only the specified column
* table: This is the actual table object, not the string ID (e.g. BO.F_Table)
* column: This is the string of the columnID that you want to seach
* entry: this is the value of what you want to search for, the data type should match that of the column you are searching (i.e. string, int, date)
*/
app.getSharedData().checkTableForEntry= function(table, column, entry) {
  var entryFound = false;
  for(var i = 0; i < table.getLength(); i++) {
    if(get(table.get(i),column).getValue() === entry) {
      entryFound = true;
      break;
    }
  }

  return entryFound;
}

/* Count the number of times that entry exists in the table, checks only the specified column
* table: This is the actual table object, not the string ID (e.g. BO.F_Table)
* column: This is the string of the columnID that you want to seach
* entry: this is the value of what you want to search for, the data type should match that of the column you are searching (i.e. string, int, date)
*/
 
app.getSharedData().countTableRowsForEntry= function(table, column, entry) {
  var entryFoundCount = 0;
  for(var i = 0; i < table.getLength(); i++) {
    if(get(table.get(i),column).getValue() === entry) {
      entryFoundCount++;
    }
  }
  return entryFoundCount;
 
}

/*
* Returns the sum of columnA for all the rows where columnB matches the specified entry.
* For example: Sum all the 'currency fields' in the rows where dropdown = 'approved'
*
* table - pass the table object - BO.F_Table
* columnA - the string ID of the field to be part of the summation
* columnB - the string ID of the field used to determine if the row should be included
* entry - the string value to compare against columnB
*/
app.getSharedData().sumColumnA_searchByColumnB = function(table, columnA, columnB, entry) {  
  var sum = 0;
  for(var i = 0; i < table.getLength(); i++) {
    if(get(table.get(i),columnB).getValue() === entry) {
      sum += parseInt(get(table.get(i),columnA).getValue());
    }
  }
  return sum;
}

/**
* Copy all the rows from one table to another.  This assumes that the tables have
* the same number of rows and it will copy the columns in order.  There is no error
* checking so if you try to copy a datatype that does not match it may throw a runtime error.
*
* sourceTable - The table object you want to copy (e.g. BO.F_Table)
* targetTable - The table object you want to copy into (e.g. BO.F_Table1)
* clearTable - true/false - If true will empty the target table before copying.
*
* USAGE: In the event where you want to trigger the function place code like:
*            app.getSharedData().copyRowsToAnotherTable(BO.F_Table, BO.F_Table0, true);
*/
app.getSharedData().copyRowsToAnotherTable = function(sourceTable, targetTable, clearTable) {
    if(clearTable) {
        targetTable.setValue(new Array());
    }

  for(var i = 0; i < sourceTable.getLength(); i++) {
      var row = sourceTable.get(i);
      var newRow = targetTable.createNew();

      //loop through all the columns of the source table
      var cols = row.getChildren();
      for(var j=0;j<cols.getLength();j++) {
          //get the row object of the target table

          var newCols = newRow.getChildren();

          //for each row of the source table we set the value into the same row of the target table
          newCols.get(j).setValue(cols.get(j).getValue());
      }
        targetTable.add(newRow);
  }
}

/* Change the order of the table by moving a row up one position.
*
* theTable: the BO object of the table
* theRow: the BO object of the row to be moved
*
* usage: Place in a button's onClick event:
*   app.getSharedData().moveSelectionUp(BO.F_InputParameters, page.F_InputParameters.getSelection())
*   page.F_InputParameters.setSelection(-1);
*
* Clearing the selection after moving a row is critical otherwise errors may insue.
*/
app.getSharedData().moveSelectionUp = function(theTable, theRow) {
    var rowObjs = new Array();
    var rowMoved = false;

    //remove all rows from the table
    //store each row in a separate array
    while(theTable.getLength() > 0) {
        rowObjs.push(theTable.get(0));
        theTable.remove(theTable.get(0));
    }
    for(var i = 0; i < rowObjs.length; i++) {
        var firstRow = get(rowObjs, i);
        var secondRow = get(rowObjs, i+1); 

        if(!rowMoved) {
            if(secondRow === theRow) {
                //add second row first, then the current row
                theTable.add(secondRow);
                i++; //increment counter again because we just processed two rows in one loop
                rowMoved = true;
            }
        }
        theTable.add(firstRow);
    }
}

/* Change the order of the table by moving a row down one position.
*
* theTable: the BO object of the table
* theRow: the BO object of the row to be moved
*
* usage: Place in a button's onClick event:
*   app.getSharedData().moveSelectionDown(BO.F_InputParameters, page.F_InputParameters.getSelection())
*   page.F_InputParameters.setSelection(-1);
*
* Clearing the selection after moving a row is critical otherwise errors may insue.
*/
app.getSharedData().moveSelectionDown = function(theTable, theRow) {
    var rowObjs = new Array();
    var rowMoved = false;
    //remove all rows from the table
    //store each row in a separate array
    while(theTable.getLength() > 0) {
        rowObjs.push(theTable.get(0));
        theTable.remove(theTable.get(0));
    }
    for(var i = 0; i < rowObjs.length; i++) {
        var firstRow = get(rowObjs, i);
        // check to make sure we are not the last row, if we are just put the row back in the table
        if(i < rowObjs.length - 1) {

          var secondRow = get(rowObjs, i+1);

          if(!rowMoved) {

            if(firstRow === theRow) {
                //add second row, then the current row
                theTable.add(secondRow);
                i++; //increment counter again because we just processed two rows in one loop
                rowMoved = true;
            }
          }

        }
        theTable.add(firstRow);
    }
}

/* prints all the columns of the table */
  app.getSharedData().printTable = function(table) {
var s = "<p>"; //can change your html properties here
 
  //loop through all the table rows
  for(var i = 0; i < table.getLength(); i++) {
    var row = table.get(i); //get the first row
    var ol = row.getChildren(); //get the list object that contains the row fields
    for(var j=0;j<ol.getLength();j++) {
    var f = ol.get(j);
    var v = f.getValue();
    s += f.getID() + ": " + v + "<BR />"; //this controls the formatting of each column in the table row
    }
    s += "<BR /><BR />"; //this controls what happens when we move to the next row
  }
  s += "</p>"; //close the html elements that were started at the beginning
  return s;
}

/** Returns a random number between the numbers specified. */

app.getSharedData().randomFromInterval = function(from,to) {
    return Math.floor(Math.random()*(to-from+1)+from);
}


/** Randomizes the selections of the specified list item.
*  usage: in the onShow event of the list you want to randomize place: app.getSharedData().randomList(item);
*/
app.getSharedData().randomList = function(theItem) {
    //store the current value
    var value = theItem.getBOAttr().getValue();

     //set up the arrays
     var arrOptions = theItem.getOptions();
     var tmpOptions = theItem.getOptions();
     var newOptions = new Array();

     //Randomise the list
     if(arrOptions !== null) {
        for ( var i = 0; i < arrOptions.length; i++ ) {
           //the random number should be between 0 and the length of the array
           var j = app.getSharedData().randomFromInterval(0,tmpOptions.length-1);
           var temp = get(tmpOptions, j);

           //assign the item to the new array
           newOptions.push(temp);

           //remove the item from the temp array
           tmpOptions.splice(j, 1);
        }

        //Set the options back
        theItem.setOptions(newOptions);
        //reset back to the current value
        theItem.getBOAttr().getValue(value);
     }
}

/**
* Returns the Label of the dropdown item, searches by value
*/
app.getSharedData().getDropdownItemTitle = function(theList, compareValue) {
    var opts = theList.getOptions();
    var retVal = "";

    //loop all the items and return if you find the compareValue
    for(var i=0;i<opts.length;i++) {                
        var theItemBO = theList.getBOAttr();
        var theItemTitle = get(get(opts,i), 'title');
        var theItemValue = get(get(opts,i), 'value');

        if(theItemValue === theItemBO.getValue()) {
          retVal = theItemTitle;
              break;
        }
    }
  return retVal;
}


/* Returns the displayed title of the checklist selection.  You pass it the value.*/
app.getSharedData().getCheckListItemTitles = function(theList, compareValue) {
      //split the compareValue into all the selected item
      var selChecks = compareValue.split("__#__");
      //for each one, get the title from the list and create a new concatenation
    var opts = theList.getOptions();
    var retVal = "";
         for(var h=0;h<selChecks.length;h++) {
             var v = get(selChecks, h);
        //loop all the items and return if you find the compareValue
        for(var i=0;i<opts.length;i++) {               
            var theItemTitle = get(get(opts,i), 'title');
            var theItemValue = get(get(opts,i), 'value');
            if(theItemValue === v) {
                if (retVal !== "") {
                  retVal += "__#__";
              }
              retVal += theItemTitle;
                  break;
            }
        }
      }
  return retVal;
}

/* This function will enforce a regex pattern on the specified field and will set the field to invalid if it does not match.
*
*/
app.getSharedData().validateByPattern = function(theItem, pattern, errMsg) {

  var re = new RegExp(pattern);

  if(!re.test(theItem.getValue())) {

    theItem.setValid(false, errMsg);

  } else {

    theItem.setValid(true, "");

  }

}

/* Returns the padded string.
* theVal - the string you want to pad
* padChar - the character you want to use to pad the string
* desiredLength - the total length the resulting string should be
*/ 
app.getSharedData.padValue = function(theVal, padChar, desiredLength) {
  while(theVal.length < desiredLength) {
    theVal = padChar + theVal;              
  }
  return theVal;
}


/*
* This is the function where you place the logic that you want to perform on the item that you are currently looking at.
* The recursive function passes the handle to the current item, from which you can then access any of its properties
*/

app.getSharedData().processItem = function(item) {

   //do whatever you want to the item...
    alert(item.getId() + " : " + item.getValue());

  //if(item.getType() === "text") {

    //do your thing

  //}

}

/*
* Returns true if the current item has children, otherwise false.
*/
app.getSharedData().hasItems = function(containerID) {
    var list = containerID.getChildren();
    if(list.getLength() > 0) {
     return true;
    } else {
        return false;
    }   
}

/*
* Recursive function used for counting form items.
* containerID: UI item (i.e. page or item)
* processItem: the function that contains the work we want to perform on the item we have accessed
*/
app.getSharedData().getItem = function(containerID, processItem) {
      var itemList;
      var pageList;
      var pageCount = 1;
      debugger;
      
      //check to see if the container is a form as it requires different processing
      if(containerID.getType() === "form") {
          pageList = containerID.getPageIds(); //list of the page IDs - not the actual objects!!
          pageCount = pageList.length;
      } else {
      itemList = containerID.getChildren();    
    }

    //need a loop to account for different pages
    for(var p=0; p<pageCount;p++) {
        if(containerID.getType() === "form") {
          itemList = containerID.getPage(get(pageList, p)).getChildren(); //get the page object from the form
        }
        
        //loop all the items
        for(var i=0; i<itemList.getLength(); i++)
        {
          var theItem = itemList.get(i);
          if(app.getSharedData().hasItems(theItem)) {
              //if container go into it...
                app.getSharedData().getItem(theItem, processItem);   
            } else {
                //other wise do something with the item
                if(dojo.isFunction(processItem)) { //make sure that the parameter passed is a function
                  processItem(theItem);        
                }
            }
        }
      }
}


/*
* Given the BO of a date field this function will return the week number the specified date
* is part of.
*
* theDt - the business object of the date field (i.e. BOA, BO.F_Date1)
*
* usage: In the onItemChange event of the date field 
*    app.getSharedData().getWeekNumberFromDate(BOA.getValue())
*/
app.getSharedData().getWeekNumberFromDate = function(theDt) {
 
if(theDt !== "") {
// Create a copy of this date object
var t = new Date(theDt);
// ISO week date weeks start on monday
// so correct the day number
var dayNr = (t.getDay() + 6) % 7;
 
// Set the target to the thursday of this week so the
// target date is in the right year
t.setDate(t.getDate() - dayNr + 3);
 
// ISO 8601 states that week 1 is the week
// with january 4th in it
var jan4 = new Date(t.getFullYear(), 0, 4);
 
// Number of days between target date and january 4th
var dayDiff = (t - jan4) / 86400000;
 
// Calculate week number: Week 1 (january 4th) plus the
// number of weeks between target date and january 4th
var weekNr = 1 + Math.ceil(dayDiff / 7);
 
return weekNr; 
} else {
return "";
}
}

/* Add number of days to a date.
* dateObj1 - The date field (i.e. BO.F_Date)
* numOfDays - The number of days to add
*/
app.getSharedData().addDaysToDate = function(dateObj1, numOfDays) {
    var d1 = dateObj1.getValue(); //get first date
    var d1_milli = d1.getTime();
  return new Date(Math.ceil(d1_milli + (1000 * 60 * 60 * 24 * numOfDays)));
}

/* Convert a standard AD date into a Buddhist Date
* dateAD: the date to convert*
* usage: Place in onLoad or beforeSubmit event to convert a
* date.  The code would be something like:
*   BO.F_DATETIME.setValue(app.getSharedData().convertToBuddhistDate(new Date()));
*/
app.getSharedData().convertToBuddhistDate = function(dateAD){
    var dateBE = new Date(dateAD);
    dateBE.setFullYear(dateAD.getFullYear() + 543);
    return dateBE;
}

/*
* Calculates the age from a specified birth date.
*
* birthDay - the date to calculate the age from
* returnAsInt - if true returns as a number, if false then a string
*
* usage: Place function in Settings...Events...Custom Actions
* BO.F_Number.setValue(app.getSharedData().getAgeFromBirthDate(BOA.getValue(), true));
* BO.F_SingleLine.setValue(app.getSharedData().getAgeFromBirthDate(BOA.getValue(), false));
*/

app.getSharedData().getAgeFromBirthDate = function(birthDay, returnAsInt) {



//calculate age

var today = new Date();

var diff_sec = today.getTime() - birthDay.getTime();

var age = diff_sec / 60 / 60 / 24 / 365 / 1000;

var returnVal = "";

//remove decimal

age = age.toString();

if(returnAsInt) {

  returnVal = parseInt(age.substr(0, age.indexOf(".")));

} else {

  returnVal = age.substr(0, age.indexOf("."));

}

return returnVal;

}


/*

* Function that can be used to check the content of a field and set it to invalid if it exceeds a specified length.
*Params:
* theItem - the UI object of the item to validate
* theLength - the max length of the field, if exceeded the field will be set to invalid
* theMsg - The text to render if the length is exceeded.
* usage:
*    - copy the entire function into the Settings...Events.
*    -  place in the onLiveItemChange event of the field to validate and change parameters as desired:
*       app.getSharedData().fieldLengthValidation(item, 3, 'Field will only accept 3 characters or less');
*/

app.getSharedData().fieldLengthValidation = function (theItem, theLength, theMsg) {
  var dval = theItem.getDisplayValue();

  if(dval.length > theLength) {
    theItem.getBOAttr().setValid(false, theMsg);
  } else {
    theItem.getBOAttr().setValid(true, '');
  }
}

/*
* Returns the sum of all the fields specified
*
* fields - array of field objects - new Array(BO.F_Field1, BO.F_Field2, ...)
*/

app.getSharedData().sumFields = function(fields) {  
  var sum = 0;
  for(var i = 0; i < fields.length; i++) {
    var f = get(fields, i);
      if(f.getValue() !== "") {
        sum += parseInt(f.getValue());
      }
     }
 
  return sum;
}

/* Returns the Month name of the specified date.
*
* theDateField - pass it the date value like BO.F_Date.getValue()
*/
app.getSharedData().getMonthNameFromDate = function(theDateField) {
var month = theDateField.getMonth();
var monthName = "";
 
switch (month) {
case 0:
monthName = "January";
break;
case 1:
monthName = "February";
break;
case 2:
monthName = "March";
break;
case 3:
monthName = "April";
break;
case 4:
monthName = "May";
break;
case 5:
monthName = "June";
break;
case 6:
monthName = "July";
break;
case 7:
monthName = "August";
break;
case 8:
monthName = "September";
break;
case 9:
monthName = "October";
break;
case 10:
monthName = "November";
break;
case 11:
monthName = "December";
break;
}
 
return monthName;
}