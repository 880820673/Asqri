/*! BuddyDrive - v2.1.0 - 2017-04-11 11:17:17 PM UTC - https://github.com/mrpritchett/buddydrive/ */
window.buddydrive=window.buddydrive||{},function(a,b){buddydrive.App={start:function(){this.views=new Backbone.Collection,this.items=new buddydrive.Collections.Items,this.router=new buddydrive.App.Router,this.Query=new buddydrive.Models.Query(_.pick(buddydrive.Settings,"buddydrive_scope")),1e3>b("#buddydrive-main").width()&&b("#buddydrive-main").addClass("mini"),Backbone.history.start()},listFiles:function(){this.cleanScreen();var a=new buddydrive.Views.Main({collection:this.items});this.views.add({id:"files",view:a}),a.inject("#buddydrive-main")},editFile:function(a){this.cleanScreen();var b=new buddydrive.Views.EditForm({model:this.items.get(a),item_id:a,collection:this.items});this.views.add({id:"edit",view:b}),b.inject("#buddydrive-main")},cleanScreen:function(){_.isUndefined(this.views.models)||(_.each(this.views.models,function(a){a.get("view").remove()},this),this.views.reset())}},buddydrive.App.Router=Backbone.Router.extend({routes:{"edit/:id":"editItem","view/:id":"viewItem","user/:id":"userFilter","":"listView"},editItem:function(a){a&&buddydrive.App.editFile(a)},viewItem:function(a){a&&(buddydrive.App.Query.set({buddydrive_parent:a,paged:1},{silent:!0}),buddydrive.App.listFiles())},userFilter:function(a){a&&(buddydrive.App.Query.set({user_id:a,paged:1},{silent:!0}),buddydrive.App.listFiles())},listView:function(){var a=_.omit(buddydrive.App.Query.attributes,["buddydrive_parent","user_id"]);buddydrive.App.Query.clear({silent:!0}),buddydrive.App.Query.set(_.extend(a,{paged:1}),{silent:!0}),buddydrive.App.listFiles()}}),buddydrive.App.start()}(buddydrive,jQuery);