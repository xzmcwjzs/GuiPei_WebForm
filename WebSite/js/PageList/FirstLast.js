/// <reference path="../jquery-1.7.2.js" />
function Go(pageCount) {
    var reg = /^[0-9]*[1-9][0-9]*$/;
    if (reg.test($("#index").val()) && parseInt($("#index").val()) <= pageCount) {
        loadPageList(parseInt($("#index").val()));

    } else {
        alert("请输入正确的页码值");
        return;
    }
}
function prevPage(pi) {
    if (pi > 1) return pi - 1;
    else return 1;
}
function lastPage(pi, pageCount) {
    if (pi < pageCount) return pi + 1;
    else return pageCount;
}