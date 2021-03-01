
    function gObj(obj) { var theObj; if (document.all) { if (typeof obj == "string") { return document.all(obj); } else { return obj.style; } } if (document.getElementById) { if (typeof obj == "string") { return document.getElementById(obj); } else { return obj.style; } } return null; }

    function formatAsMoney(num) { return formatAsMoneyFull(num, 1); }
    function formatAsMoneyFull(num, hascents) {
        num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num)) num = "0";
    sign = (num == (num = Math.abs(num)));
    cents = '';
        if (hascents == 1) {
        num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
            if (cents < 10) cents = "0" + cents;
    cents = "." + cents;
        } else {
        num = Math.floor(num + 0.50000000001).toString();
    }
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++) num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + cents);
}
var linelabels = [];
var datalist = [];
    function addMonths(date, months) {
        var d = date.getDate();
    date.setMonth(date.getMonth() + +months);
        if (date.getDate() != d) {
        date.setDate(0);
    }
    var month = date.getMonth()+1;
    var day = date.getDate();
        if (day < 10) {
        day = '0' + day;
    }
        if (month < 10) {
        month = '0' + month;
    }
    var year = date.getFullYear();
        var dateFormat = day + "-" + month + "-" + year;
        var monthyear = "" + month + "";
      
        linelabels.push(dateFormat);
     
    return dateFormat;
  
}

function showLoanCalaculation(jcloanamount, jtotalloantermtimes, loanDate,mode) {
 
    var loanCurrentDate = loanDate;
    var jinterestRatePerPeriod = 0;    
    var jpaymentPerperiod = Math.floor(jcloanamount / jtotalloantermtimes);
    var jcpayback = 'month';
    var jdivid = "tbEMIdetail";
    var date = "tbEMIdetail";
    var outputStrBuilder = [];
        linelabels = [];
        datalist = [];
    var saBeginningBalance = jcloanamount;
    var intTerm = Math.floor(jtotalloantermtimes);
    var remainingTerm = jtotalloantermtimes - intTerm;
        for (i = 0; i < intTerm; i++) {
            var thisInterest = saBeginningBalance * jinterestRatePerPeriod;
    var thisPrincipal = jpaymentPerperiod - thisInterest;
    var thisEndingBalance = saBeginningBalance - thisPrincipal;
            if ((i % 2) == 1) {
        outputStrBuilder.push("<tr align=right><td>" + (i + 1));
    } else {
        outputStrBuilder.push("<tr align=right ><td>" + (i + 1));
    }
            if (jcpayback == "halfyear") {
                var thisYear = Math.floor((i + 2) / 2);
    outputStrBuilder.push(". Year #" + thisYear);
}
            outputStrBuilder.push("</td> <td>" + addMonths(new Date(loanCurrentDate.split('-')[2], loanCurrentDate.split('-')[1], loanCurrentDate.split('-')[0]), i));
           
            outputStrBuilder.push("</td> <td>" + formatAsMoney(thisPrincipal));
            outputStrBuilder.push("</td> <td>" + formatAsMoney(saBeginningBalance));
            outputStrBuilder.push("</td> <td>" + formatAsMoney(thisEndingBalance) + "</td></tr > ");
            saBeginningBalance = thisEndingBalance;
            datalist.push(thisEndingBalance);
if (i > 0) {
    if (jcpayback == "halfmonth") {
        if (((i + 1) % 24) == 0) {
            var thisYear = Math.floor((i + 1) / 24);
            outputStrBuilder.push("<tr align=center ><td colspan='5'><b>Year #" + thisYear + " End</b></td></tr>");
        }
    } else if (jcpayback == "month") {
        if (((i + 1) % 12) == 0) {
            var thisYear = Math.floor((i + 1) / 12);
            outputStrBuilder.push("<tr align=center ><td colspan='5'><b>Year #" + thisYear + " End</b></td></tr>");
        }
    } else if (jcpayback == "quarter") {
        if (((i + 1) % 4) == 0) {
            var thisYear = Math.floor((i + 1) / 4);
            outputStrBuilder.push("<tr align=center ><td colspan='5'><b>Year #" + thisYear + " End</b></td></tr>");
        }
    }
}
        }
if (remainingTerm > 0.0001) {

    outputStrBuilder.push("<tr align=right ><td>" + (intTerm + 1));
    outputStrBuilder.push(" (Partial)</td><td>" + addMonths(new Date(loanCurrentDate.split('-')[2], loanCurrentDate.split('-')[1], loanCurrentDate.split('-')[0]), i)+"</td><td>" + formatAsMoney(saBeginningBalance) + "</td><td>" + formatAsMoney(saBeginningBalance) + "</td><td>" + formatAsMoney(0) + "</td></tr>");
}
    if (mode == 1) {

   
        var lineChartData = {
          
            labels: linelabels,//["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "My First dataset",
                fillColor: "rgba(255,255,255,0.2)",
                strokeColor: "rgba(255,255,255,1)",
                pointColor: "rgba(255,255,255,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(255,255,255,1)",
                data: datalist
            }
               
        ]
        };
        

        var ctx2 = document.getElementById("line-chart").getContext("2d");
        window.myLine = new Chart(ctx2).Line(lineChartData, {
            responsive: true
        });
    }
var outPutString = outputStrBuilder.join("");
        gObj(jdivid).innerHTML = outPutString;
     
return false;
}



