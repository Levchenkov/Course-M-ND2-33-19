var Post = (function () {

    var title = null;

    function Post() {
        this.publicField = null;
    }

    Post.prototype.SetTitle = function(value) {
        title = value;
    };

    Post.prototype.GetTitle = function() {
        return title;
    };

    return Post;
})();