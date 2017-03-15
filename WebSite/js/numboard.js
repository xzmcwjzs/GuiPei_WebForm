// JavaScript Document

function addNum( val ,obj)
{
	var txtObj=	obj.value;
	if(txtObj.length<=17)
	{				
		txtObj = txtObj +val;
		obj.value = txtObj;
	}
	else{
		alert("身份证长度不能大于18位");
	}
}
function subNum(obj)
{
	var txtObj=	obj.value;
	if(txtObj.length>=1)
	{				
		txtObj = txtObj.substring(0,txtObj.length-1);
		obj.value = txtObj;
	}
	else{
	}
}