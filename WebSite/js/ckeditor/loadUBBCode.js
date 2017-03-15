function loadUBBCode() {
    CKEDITOR.replace('NewsContent',
{
    extraPlugins: 'bbcode',
    removePlugins: 'bidi,button,dialogadvtab,div,filebrowser,flash,format,forms,horizontalrule,iframe,indent,justify,liststyle,pagebreak,showborders,stylescombo,table,tabletools,templates',
    toolbar:
    [
        ['Source', '-', 'Save', 'NewPage', '-', 'Undo', 'Redo'],
        ['Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Link', 'Unlink', 'Image'],
        '/',
        ['FontSize', 'Bold', 'Italic', 'Underline'],
        ['NumberedList', 'BulletedList', '-', 'Blockquote'],
        ['TextColor', '-', 'Smiley', 'SpecialChar', '-', 'Maximize']
    ],
    smiley_images:
    [
        'regular_smile.gif', 'sad_smile.gif', 'wink_smile.gif', 'teeth_smile.gif', 'tounge_smile.gif',
        'embaressed_smile.gif', 'omg_smile.gif', 'whatchutalkingabout_smile.gif', 'angel_smile.gif', 'shades_smile.gif',
        'cry_smile.gif', 'kiss.gif'
    ],
    smiley_descriptions:
    [
        'smiley', 'sad', 'wink', 'laugh', 'cheeky', 'blush', 'surprise',
        'indecision', 'angel', 'cool', 'crying', 'kiss'
    ]
});
}