mergeInto(LibraryManager.library, {

  SendObjName: function (myVar) {
    getObjInfo(Pointer_stringify(myVar));
    console.log("angekommen");
  },
  
  TutAnchor: function() {
    jumpToTutorial();
  },
  
});