
function showROCDate( date )
{
	if( null==date || ''==date ) return '';
	var dateArray = date.split('-');
	var yy = dateArray[0];
	var mm = dateArray[1];
	var dd = dateArray[2];
	
	yy = parseInt(yy, 10) - 1911;
	if( yy<100 )
		yy = '0'+yy;
	
	return yy+'/'+mm+'/'+dd;
}

function parseROCDate( roc )
{
	var rdate = "";
	try{
		if( null==roc || roc.length !=9 ) throw SyntaxError("date invalid"); 
	
		var str = roc.split("/");
		if( null==str || str.length !=3 ) throw SyntaxError("date invalid"); 

		var yy = parseInt(str[0],10)+1911;
		var mm = str[1];
		var dd = str[2];

		//檢查年份
		if (parseInt(yy,10)<0) throw SyntaxError("date invalid");

		//檢查月份
		if ((parseInt(mm,10)<1)||(parseInt(mm,10)>12)) throw SyntaxError("date invalid");

		//檢查大月日期
		if (((parseInt(mm,10)==1)||(parseInt(mm,10)==3)||(parseInt(mm,10)==5)||(parseInt(mm,10)==7)||(parseInt(mm,10)==8)||(parseInt(mm,10)==10)||(parseInt(mm,10)==12))&&((parseInt(dd,10)<1)||(parseInt(dd,10)>31)))
			throw SyntaxError("date invalid");

		//檢查小月日期
		if (((parseInt(mm,10)==4)||(parseInt(mm,10)==6)||(parseInt(mm,10)==9)||(parseInt(mm,10)==11))&&((parseInt(dd,10)<1)||(parseInt(dd,10)>30)))
			throw SyntaxError("date invalid");

		//檢查二月日期
		if (parseInt(mm,10)==2)
		{
			//a =(((parseInt(yy,10)+1911)%100==0)&&((parseInt(yy,10)+1911)%400!=0)||((parseInt(yy,10)+1911)%4!=0));
			a =((yy%100==0)&&(yy%400!=0)||(yy%4!=0));
			b =((parseInt(dd,10)<1)||(parseInt(dd,10)>28));

			if (a&&b)   //檢查非閏年
			{
				throw SyntaxError("date invalid");
			}
			else        //檢查閏年
			{
				if ((parseInt(dd,10)<1)||(parseInt(dd,10)>29))
		 		{
					throw SyntaxError("date invalid");
				}
			}
		}

		rdate = yy+'-'+mm+'-'+dd;
	}catch(e){
		//alert(e.message);
		rdate = "";
		alert('日期格式錯誤，標準格式為YYY/MM/DD，請重新輸入!');
	}
	return rdate;
}

