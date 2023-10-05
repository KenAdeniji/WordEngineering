// http://developer.nokia.com/Community/Wiki/JavaScript_Performance_Best_Practices
// JavaScript
function loadScript(src, callback) {
    var head = document.getElementsByTagName('head')[0],
        script = document.createElement('script');
    done = false;
    script.setAttribute('src', src);
    script.setAttribute('type', 'text/javascript');
    script.setAttribute('charset', 'utf-8');
    script.onload = script.onreadstatechange = function() {
        if (!done && (!this.readyState || this.readyState == 'loaded' || this.readyState == 'complete')) {
            done = true;
            script.onload = script.onreadystatechange = null;
                if (callback) {
                    callback();
                }
            }
    }
    head.insertBefore(script, head.firstChild);
}
 
// load the my-script-file.js and display an alert dialog once the script has been loaded
loadScript('my-script-file.js', function() { alert('my-script-file.js loaded.'); })