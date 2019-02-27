define([
// Dojo
        "dojo",
        "dojo/_base/declare",
        "dojo/aspect",
//CMS
        "epi/_Module",
        "epi/dependency",
        "epi/routes",
        "epi-cms/store/CustomQueryEngine"
], function (
// Dojo
        dojo,
        declare,
        aspect,
//CMS
        _Module,
        dependency,
        routes,
        CustomQueryEngine
    ) {

    return declare("walmart.one.ModuleInitializer", [_Module], {
        initialize: function () {
            this.inherited(arguments);

            var registry = this.resolveDependency("epi.storeregistry");
            //Register the supported display options store
            registry.create("supporteddisplayoptions", this._getRestPath("supporteddisplayoptions"));
        },

        _getRestPath: function (name) {
            return routes.getRestPath({ moduleArea: "app", storeName: name });
        }
    });
});