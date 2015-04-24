// JScript 檔

// Parent 網頁
function getListItem(objID)
{   
    var listObj=document.getElementById(objID);
    var listType=listObj.type;
    var arrayObj=null;
    switch (listType)
    {
        case 'hidden':
            arrayObj=textToArray(objID);
            break;
        case 'text':
            arrayObj=textToArray(objID);
            break;
        case 'select-multiple': 
            arrayObj=listToArray(objID);
            break;
        case 'select-one':
            arrayObj=listToArray(objID); 
            break;
        default:
            alert(listType);
            break;
    }
    return arrayObj;
}

function buildListItem(txtObjID,valueItemObjID)
{
    var txtObj=document.getElementById(txtObjID);
    var valueItemObj=document.getElementById(valueItemObjID);
    var arrayObj=new Array();
    if (valueItemObj.value.length>0)
    {
        var spvalue=valueItemObj.value.split(';');
        var sptext=txtObj.value.split(';');
        for(i=0;i<spvalue.length;i++)
        {
            if (spvalue[i].length>0)
            {
                arrayObj[i]=new Array(sptext[i],spvalue[i]);
            }
        }
    }
    return  arrayObj;
}

function getSelectedItem(objID)
{
    var listObj=document.getElementById(objID);
    var listSelectedIndex=listObj.selectedIndex; 
    var arrayObj=new Array();
    if (listSelectedIndex>=0)
    { 
        var current = listObj.options[listSelectedIndex]; 
        arrayObj[0]=new Array(current.text,current.value);
    }
    return arrayObj;
}

function textToArray(objID)
{
    var textObj=document.getElementById(objID);
    var arrayObj=new Array();
    if (textObj.value.length>0)
    {
        var listArray=textObj.value.split(';');
        for(i=0;i<listArray.length;i++)  
        {
            if (listArray[i].length>0)
            {
                arrayObj[i]=new Array(listArray[i],listArray[i]);
            }
        }  
    }
    return arrayObj;
}

function listToArray(objID){
  var listObj=document.getElementById(objID);
  var arrayObj=new Array();
  for(i=0;i<listObj.options.length;i++)  {
		arrayObj[i]=new Array(listObj.options[i].text,listObj.options[i].value);
		}  
return arrayObj;		

}

function setListItem(listID,arrayObj)
{
    var listObj=document.getElementById(listID);
    listObj.length=0;
    for(i=0;i<arrayObj.length;i++)  
    {
        listObj.options[i]=new Option(arrayObj[i][0],arrayObj[i][1]);
    } 
}

function setText(txtID,arrayObj)
{
    var txtObj=document.getElementById(txtID);
    txtObj.value='';
    for(i=0;i<arrayObj.length;i++)  
    {
        txtObj.value+=arrayObj[i][0]+';';
    }  
}

function setValueItem(txtID,arrayObj)
{
    var txtObj=document.getElementById(txtID);
    txtObj.value='';
    for(i=0;i<arrayObj.length;i++)  
    {
        txtObj.value+=arrayObj[i][1]+';';
    }  
}

function setDepartmentDisplay(txtID,arrayObj,returnType)
{

var txtObj=document.getElementById(txtID);
    var txtObjType=txtObj.type;
    if (txtObjType=='text')
    {
        txtObj.value='';
        for(i=0;i<arrayObj.length;i++)  
        {
        
         //  txtObj.value+=arrayObj[i][0];
         
         try{
            
             var deptInfo=new departmentInfoObj(arrayObj[i][1]);
             
          
            
              switch(returnType)
             {
             case "0":
                      txtObj.value+=deptInfo.fullname+';';
                      break;
                
             case "1":
                      txtObj.value+=deptInfo.name+';';
                      break;
             case "2":
                    break;
             
             
             }
            
            
            }
            catch(e)
            {
             alert(e);
            
            }
            

        }
    }
    else
    {
        txtObj.innerHTML='';
        for(i=0;i<arrayObj.length;i++)  
        {
        
       // txtObj.innerHTML+=arrayObj[i][0]+'<br>';
       
       try{        
            var deptInfo=new departmentInfoObj(arrayObj[i][1]);
        
              
               switch(returnType)
             {
             case "0":
                     txtObj.innerHTML+=deptInfo.fullname+';';
                     break;
                
             case "1":
                      txtObj.innerHTML+=deptInfo.name+';';
                      break;
             case "2":
                    break;
             }
            
           }
           catch(e)
           {
           alert(e);
           } 
            
        }  
    }

}

function setPersonDisplay(txtID,arrayObj,returnType)
{ 
    var txtObj=document.getElementById(txtID);
    var txtObjType=txtObj.type;
    if (txtObjType=='text')
    {
        txtObj.value='';
        for(i=0;i<arrayObj.length;i++)  
        {
        
         //  txtObj.value+=arrayObj[i][0];
         
     
         try{
            
             var personInfo=new personInfoObj(arrayObj[i][1]);
             
        
            
         switch(returnType)
         {
         case "0":
             txtObj.value+=personInfo.name+' '+personInfo.name2+';';
             break;
         case "1":
          txtObj.value+=personInfo.name+';';
          break;
         case "2":
            break;
         
         }
         
            
            }
            catch(e)
            {
             alert(e);
            
            }
            
           
        }
    }
    else
    {
        txtObj.innerHTML='';
        for(i=0;i<arrayObj.length;i++)  
        {
        
       // txtObj.innerHTML+=arrayObj[i][0]+'<br>';
       
       try{        
           var personInfo=new personInfoObj(arrayObj[i][1]);
        
            
               switch(returnType)
                 {
                 case "0":
                     txtObj.innerHTML+=personInfo.name+' '+personInfo.name2+';';
                     break;
                 case "1":
                  txtObj.innerHTML+=personInfo.name+';';
                  break;
                 case "2":
                 break;
                 
                 }
         
           }
           catch(e)
           {
           alert(e);
           } 
            
        }  
    }
}


function fnShowTwoWayDialog(path,dlgStyle,isMulti,isRepeat,receiveObjID,dlgObjID,titleText,desText,dialogType,returnType)
{
    document.getElementById(dlgObjID+'_hidden').value='';
    document.getElementById(dlgObjID+'_hiddenTemp').value='';
    document.getElementById(dlgObjID+'_hiddenTempTxt').value='';
    var args=new Array(8);
    args[0]=window;
    args[1]=buildListItem(dlgObjID+'_txt',dlgObjID+'_ValueItem');
    args[2]=isMulti;
    args[3]=isRepeat;
    args[4]=receiveObjID;
    args[5]=dlgObjID;
    args[6]=escape(titleText);
    args[7]=escape(desText); 
     args[8]=dialogType;
      args[9]=returnType;
    
    retVal=window.showModalDialog(path,args,dlgStyle);
    return retVal;
}

function fnShowOneWayDialog(path,dlgStyle,receiveObjID,dlgObjID,titleText,desText,dialogType,returnType)
{
    document.getElementById(dlgObjID+'_hidden').value='';
    document.getElementById(dlgObjID+'_hiddenTemp').value='';
    document.getElementById(dlgObjID+'_hiddenTempTxt').value='';
    var args=new Array(5);
    args[0]=window;
    args[1]=receiveObjID;
    args[2]=dlgObjID;
    args[3]=escape(titleText);
    args[4]=escape(desText);
     args[5]=dialogType;
      args[6]=returnType;
    retVal=window.showModalDialog(path,args,dlgStyle);
}


//Dialog page
//--------------------------------------------------------------------------
var dlgTitleID='lblTitle';
var dlgDesID='lblDescription';
var chosenObjID='ChosenList';
var possibleObjID='PossibleList';
var keepFlagID='hiddenTemp';
var amountObjID='txtAmount';

var itemObj=null;
var receiveObjID=null;
var titleValue=null;
var desValue=null;
var isMulti=null;
var isRepeat=null;

var dlgObjID=null;
var hiddenObjID=null;
var hiddenTempObjID=null;
var hiddenTxtObjID=null;
var hiddenTempTxtObjID=null;
var dialogType=null;
var returnType=null;
//--------------------------------------------------------------------------

function fnOneWayOnload()
{
    window.parent.window.opener = dialogArguments[0];
    receiveObjID=dialogArguments[1];
    dlgObjID=dialogArguments[2];
    titleValue=dialogArguments[3];
    desValue=dialogArguments[4];
     dialogType=dialogArguments[5];
     returnType=dialogArguments[6];
    hiddenObjID=dlgObjID+'_hidden';
    //// set title
    setDialogText(dlgTitleID,titleValue);
    ////set Description
    setDialogText(dlgDesID,desValue);
}

function fnTwoWayOnload()
{
    window.parent.window.opener = dialogArguments[0];
    itemObj = dialogArguments[1];
    isMulti=dialogArguments[2];  
    isRepeat=dialogArguments[3];
    receiveObjID=dialogArguments[4];
    dlgObjID=dialogArguments[5]; 
    hiddenObjID=dlgObjID+'_hidden';
    hiddenTempObjID=dlgObjID+'_hiddenTemp';
    hiddenTxtObjID=dlgObjID+'_txt';
    hiddenTempTxtObjID=dlgObjID+'_hiddenTempTxt';
    titleValue=dialogArguments[6];
    desValue=dialogArguments[7];
     dialogType=dialogArguments[8];
     returnType=dialogArguments[9];
    var tempItemObj=window.parent.window.opener.getHiddenTemp(hiddenTempTxtObjID,hiddenTempObjID);
    if (tempItemObj.length==0)
    {
        window.parent.window.opener.setHiddenTemp(dlgObjID,itemObj);
    }
    else
    {
        itemObj=tempItemObj;
    }
    ////set chosen list
    setListItem(chosenObjID,itemObj);

    if ((!isMulti) && (!isRepeat))
    { 
        disableOrderCtl();
    }
    //// set title
    setDialogText(dlgTitleID,titleValue);  
    ////set Description
    setDialogText(dlgDesID,desValue);
}


function getObjType(objID)
{
    var obj=document.getElementById(objID);
    alert(obj.type);
}


function setDialogText(txtID,txtValue)
{
    var txtObj=document.getElementById(txtID);
    try
    {
        txtObj.innerText=unescape(txtValue);
    }
    catch (e) {

    }
}

function updateHiddenTemp()
{
    var retVal=getListItem(chosenObjID)
    window.parent.window.opener.setHiddenTemp(dlgObjID,retVal);
}

function submitTwoWayData()
{
    var retVal =null;
    retVal = getListItem(chosenObjID);
    window.returnValue = retVal;
    window.parent.window.opener.receiveData(dlgObjID,retVal,dialogType,returnType);
    closeDialog();
}

function closeDialog()
{
    window.parent.window.close();
}

function showChosen(Type)
{
    var listObj=document.getElementById(chosenObjID);
    var listSelectedIndex=listObj.selectedIndex;
    var listAmount=document.getElementById(amountObjID);
    
    if(listSelectedIndex >= 0)
    {
        if(Type == 'Dept')
        {
            var tmpArray = new departmentInfo2(listObj.options[listSelectedIndex].value);
            listAmount.value = tmpArray.amount
        }
        else if(Type == 'Person')
        {
            var tmpArray = new personInfo2(listObj.options[listSelectedIndex].value);
            listAmount.value = tmpArray.amount
        }
    }
}

function addToChosenList()
{
    var fromList=document.getElementById(possibleObjID);
    var toList=document.getElementById(chosenObjID);
    var toListAmount=document.getElementById(amountObjID);
    
    if (toListAmount.value == '')
    {
        alert("請填份數");
        return;
    }
    else
    {
        if (!isNaN(toListAmount.value))
        {
            amount = parseInt(toListAmount.value);
            if (amount <= 0)
            {
                alert("份數不得小於等於零");
                return;
            }
        }
        else
        {
            alert("份數格式錯誤");
            return;
        }
    }
    
    if (toList.options.length > 0 && toList.options[0].value == 'temp')	
    {
        toList.options.length = 0;
    }	
    var sel = false;
    for (i=0;i<fromList.options.length;i++)	
    {
        var current = fromList.options[i]; 
        if (current.selected)
        { 
            sel = true;
            if (current.value == 'temp')
            {
                alert ('You cannot move this text!'); 
                return; 
            }	
            txt = current.text;
            val = current.value + ',' + toListAmount.value;
            var chk=false;

            // check if allow repeat 
            if (!isRepeat)
            {
                for(j=0;j<toList.length;j++)
                {
                    if(val==toList.options[j].value)  
                    {
                        chk=true;
                        alert('The option['+ toList.options[j].text+'] have already existed!');
                    }
                    else if((val.split(","))[0] == (toList.options[j].value.split(","))[0])
                    {
                        sTemp = toList.options[j].value.split(',');
                        chk=true;
                        toList.options[j].value = '';
                        for(k=0;k<sTemp.length-1;k++)
                        {
                            toList.options[j].value += sTemp[k] + ',';
                        }
                        toList.options[j].value += toListAmount.value;
                    } 
                }
            }
            if (!chk) 
            {
                toList.options[toList.length] = new Option(txt,val);
            }
        }
    }	
    if (!sel) alert ('You haven\'t selected any options!');
}


function addToList()
{
    if (isMulti)addMultiValue(); 
    else
    addSingleValue();
}

function addSingleValue()
{
    var fromList=document.getElementById(possibleObjID);
    var toList=document.getElementById(chosenObjID);
    var fromSelectedIndex=fromList.selectedIndex; 
    if (fromSelectedIndex>=0) 
    { 
        var current = fromList.options[fromSelectedIndex]; 
        txt = current.text;
        val = current.value;
        // allow repeat
        if (isRepeat)
        { 
            toList.options[toList.length]=new Option(txt,val);
        }
        else
        {
            toList.length=0;
            toList.options[0]=new Option(txt,val);
        }
    }
    else
    { alert ('You haven\'t selected any options!'); 
    }
}

function addMultiValue()
{
    var fromList=document.getElementById(possibleObjID);
    var toList=document.getElementById(chosenObjID);
    if (toList.options.length > 0 && toList.options[0].value == 'temp')	
    {
        toList.options.length = 0;
    }	
    var sel = false;
    for (i=0;i<fromList.options.length;i++)	
    {
        var current = fromList.options[i]; 
        if (current.selected)
        { 
            sel = true;
            if (current.value == 'temp')
            {
                alert ('You cannot move this text!'); 
                return; 
            }	
            txt = current.text;
            val = current.value;
            var chk=false;

            // check if allow repeat 
            if (!isRepeat)
            {
                for(j=0;j<toList.length;j++)
                {
                    if(val==toList.options[j].value)  
                    {
                        chk=true;
                        alert('The option['+ toList.options[j].text+'] have already existed!');
                    } 
                }
            }
            if (!chk) 
            {
                toList.options[toList.length] = new Option(txt,val);
            }
        }
    }	
    if (!sel) alert ('You haven\'t selected any options!');
}

function removeChosen()
{
    var listObj=document.getElementById(chosenObjID);
    var listSelectedIndex=listObj.selectedIndex;
    
    if (listSelectedIndex>=0) 
    { 
        listObj.options[listSelectedIndex]=null
    }
    else
    {
        alert ('You haven\'t selected any options!');
    }
}

function removeChosenAmt()
{
    var listObj=document.getElementById(chosenObjID);
    var listSelectedIndex=listObj.selectedIndex;
    var listAmount=document.getElementById(amountObjID);
    
    if (listSelectedIndex>=0) 
    { 
        listObj.options[listSelectedIndex]=null
        listAmount.value = '';
    }
    else
    {
        alert ('You haven\'t selected any options!');
    }
}

function removeAllChosen()
{ 
    var List=document.getElementById(chosenObjID);
    if (List.options.length>0)
    {
        if(confirm('Are you sure remove all options?'))
        {
            List.length=0;
        }
    }
}

function removeAllChosenAmt()
{ 
    var List=document.getElementById(chosenObjID);
    var listAmount=document.getElementById(amountObjID);
    if (List.options.length>0)
    {
        if(confirm('Are you sure remove all options?'))
        {
            listAmount.value = '';
            List.length=0;
        }
    }
}

function moveChosen(direct) 
{
    var List=document.getElementById(chosenObjID);
    var currentIndex=List.selectedIndex;
    if (currentIndex>=0) 
    {
        var targetIndex;
        if (direct=='up')
        {
            if (currentIndex==0) 
                return; 
            else	
                targetIndex=currentIndex-1; 
        }
        else
        {
            if (currentIndex==List.length-1)return; 
            else targetIndex=currentIndex+1;
        } 
        var currentItem=List.options[currentIndex];
        var targetItem=List.options[targetIndex]; 
        List.options[currentIndex]=new Option(targetItem.text,targetItem.value);
        List.options[targetIndex]=new Option(currentItem.text,currentItem.value);
        List.selectedIndex=targetIndex; 
    }
}

function disableOrderCtl()
{
    document.getElementById('MoveUP').style.display='none';
    document.getElementById('MoveDown').style.display='none';
}


function sumitOneWayData()
{
    var retVal =null;
	retVal = getSelectedItem(chosenObjID);
	if (retVal.length > 0)
	{
	    window.parent.window.opener.receiveData(dlgObjID,retVal,dialogType,returnType);
 	     closeDialog();
	}
	else
	{
    	alert ('You haven\'t selected any options!');
	}	
}

function returnPersonCollectionFromValueArray(valueArray)
{
    var personinfos=new Array();
    try
        {
       
        var x = 0
        for(i=0;i<valueArray.length;i++)  {
               
	            personinfos[x]=new personInfo(listObj.options[i].value);
	            x++;
	          
	            }  
        
        }
    catch(e)
        {
            alert(e);      
        }
    
    return personinfos

}


//---------------------------------------------------------------------------

function personInfoObj(selectedvalue)
{
            
    var value_array = selectedvalue.split(",");
    
    this.id = value_array[0];
    this.name = value_array[1];
    this.name2 = value_array[2];
    this.alias = value_array[3];
    this.titleName = value_array[4];
    this.pluralism = value_array[5];
    this.deptName = value_array[6];
    this.deptName2 = value_array[7];
    this.deptFullName = value_array[8];
    this.deptFullName2 = value_array[9]; 
    this.phone = value_array[10];
    this.email = value_array[11];   

}

function departmentInfoObj(selectedvalue)
{
    var value_array = selectedvalue.split(",");
    this.id = value_array[0];
    this.name = value_array[1];
    this.name2 = value_array[2];
    this.fullname = value_array[3];
    this.fullname2 = value_array[4];
  
}