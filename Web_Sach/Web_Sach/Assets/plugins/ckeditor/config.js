/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.filebrowserBrowseUrl = "/Assets/admin/dist/js/plugins/ckfinder/ckfinder.html" /*"/Areas/Admin/assets/plugin/ckfinder/ckfinder.html";*/
    //config.filebrowserImageUrl = "/Assets/admin/dist/js/plugins/ckfinder/ckfinder.html?type=Images"    /*"/Areas/Admin/assets/plugin/ckfinder/ckfinder.html?type=Images";*/
    //config.filebrowserFlashUrl = "/Assets/admin/dist/js/plugins/ckfinder/ckfinder.html?type=Flash"     /* "/Areas/Admin/assets/plugin/ckfinder/ckfinder.html?type=Flash";*/
    //config.filebrowserUploadUrl = "/Assets/admin/dist/assets/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    //config.filebrowserImageUploadUrl = "/Assets/admin/dist/assets/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    //config.filebrowserFlashUploadUrl = "/Assets/admin/dist/assets/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    //config.extraPlugins = 'youtube';
    //config.youtube_responsive = true;

    //config.extraPlugins = 'syntaxhighlight';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Assets/plugins/ckfinder/ckfinder.html'
    config.filebrowserImageBrowseUrl = '/Assets/plugins/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/plugins/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = "/Assets/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";


    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = "/Assets/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    CKFinder.setupCKEditor(null, '/Assets/plugins/ckfinder');











};
