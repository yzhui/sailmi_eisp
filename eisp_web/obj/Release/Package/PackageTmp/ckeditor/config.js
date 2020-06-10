/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.toolbar_Simple =

    [  

    ['Bold', 'Italic', 'Underline', 'Strike'],

    ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],

    ['Link', 'Unlink', 'Anchor'],

    ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],

    ['Styles', 'Format', 'Font', 'FontSize'],

    ['TextColor', 'BGColor'],

    ['Maximize', 'ShowBlocks', '-', 'About']

    ];
};
