function setBgColorById(id,sColor) {
 var elem;
 if (document.getElementById) {
  if (elem=document.getElementById(id)) {
   if (elem.style) {
    elem.style.backgroundColor=sColor;
    return 1;  // success
   }
  }
 }
 return 0;  // failure
}

function setColorById(id,sColor) {
 var elem;
 if (document.getElementById) {
  if (elem=document.getElementById(id)) {
   if (elem.style) {
    elem.style.color=sColor;
    return 1;  // success
   }
  }
 }
 return 0;  // failure
}

function getBgColorById(id) {
 var elem;
 if (document.getElementById) {
  if (elem=document.getElementById(id)) {
   if (elem.style) return ''+elem.style.backgroundColor;
  }
 }
 return 'undefined';
}
