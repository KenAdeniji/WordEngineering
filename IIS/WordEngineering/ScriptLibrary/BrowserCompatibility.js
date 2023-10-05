var BrowserCompatibility =
{
    getNonTextNode : function(parentNode, nonTextNodeIndex)
    {
        var currentNodeType;
        var childNodesCounter = 0;
        var nonTextNodeCounter = 0;
        
        for (; childNodesCounter < parentNode.childNodes.length; childNodesCounter++)
        {
            currentNodeType = parentNode.childNodes[childNodesCounter].nodeType;
            if (currentNodeType != 3 && currentNodeType != 8)
            {
                ++nonTextNodeCounter;
                if (nonTextNodeCounter == nonTextNodeIndex)
                {
                    return parentNode.childNodes[childNodesCounter];
                }
            }
        }
        return null;
    },
    
    getTextByControl : function(control)
    {
        return(typeof(control.innerText) != "undefined") ? control.innerText :
            (typeof(control.textContent) != "undefined") ? control.textContent :
            control.innerHTML.replace(/<[^>]+>/g, '');
    },
    
    getTextById : function(controlClientId)
    {
        var control = document.getElementById(controlClientId);
        var controlText = this.getTextByControl(control);
        return controlText;
    },
    
    setTextByControl : function(control, controlText)
    {
        if ('innerText' in control) 
        {
            control.innerText = controlText;
        }
        else if ('textContent' in control) 
        {
            control.textContent = controlText;
        }
    },

    setTextById : function(controlClientId, controlText)
    {
        var control = document.getElementById(controlClientId);
        this.setTextByControl(control, controlText);
    },
    
    viewSource : function()
    {
        if (document.all)
        {
            window.location = "javascript:'<xmp>'+window.document.body.outerHTML+'</xmp>'";
        }
        else
        {
            window.location = "javascript:'<xmp>'+document.getElementsByTagName('html')[0].innerHTML+'</xmp>'";
        }
    }
}