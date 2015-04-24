
function setMsg(msg, callback) {
    var obj = document.getElementById("alertMsg");
    if (obj != null)
        obj.value = msg;
    
    var obj2 = document.getElementById("callback");
    if (obj2 != null)
        obj2.value = callback;
}
function showMsg() {
    var obj = document.getElementById("alertMsg");
    
    if (obj != null && obj.value!="") {
        alert(obj.value);
        obj.value = "";
    }

    var obj2 = document.getElementById("callback");
    if (obj2 != null) {
        var callback = obj2.value;
        setTimeout(callback, 0);
        obj2.value = "";
    }
}

function checkID(id) {
    tab = "ABCDEFGHJKLMNPQRSTUVXYWZIO"
    A1 = new Array(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3);
    A2 = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5);
    Mx = new Array(9, 8, 7, 6, 5, 4, 3, 2, 1, 1);

    if (id.length != 10) return false;
    i = tab.indexOf(id.charAt(0));
    if (i == -1) return false;
    sum = A1[i] + A2[i] * 9;

    for (i = 1; i < 10; i++) {
        v = parseInt(id.charAt(i));
        if (isNaN(v)) return false;
        sum = sum + v * Mx[i];
    }
    if (sum % 10 != 0) return false;
    return true;
}