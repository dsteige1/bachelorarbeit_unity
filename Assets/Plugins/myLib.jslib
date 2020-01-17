mergeInto(LibraryManager.library, {

  Hello: function (myVar) {
    testHello(Pointer_stringify(myVar));
    console.log("angekommen");
  },
});