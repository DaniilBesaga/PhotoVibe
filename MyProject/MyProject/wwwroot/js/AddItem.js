
function check_bool(index, boolean)
{
    document.getElementsByClassName("var")[index].querySelector("i").className = boolean ? "ri-checkbox-line" : "ri-checkbox-blank-line";
}

function Myquery(index, boolean, b) {
    console.log(index);
    console.log(boolean);
    $.ajax({
        type: "get",
        url: '/Cart/GetData',
        data: { index: index, b: boolean, type:b },
        success: function (data) {
            var e = data.replace(/&quot;/g, '"').replace(/&#xD;/g, '\r').replace(/&#xA;/g, '\n');
            e = e.replace(/&#xD;/g, '\r').replace(/&#xA;/g, '\n');
            var json = JSON.parse(e);

            var price = document.querySelector(".add-to-cart p");
            price.innerText = "EUR" + Math.round(json.Price * 100) / 100;

            var img = document.querySelector(".grid-item-img img");
            img.src = json.ImgUrl;

            check_bool(0, json.Copyright);
            check_bool(1, json.HighPrint);
            check_bool(2, json.Templates);
            check_bool(3, json.Editoral);
        }
    });
}

     //public string ImgUrl { get; set; }
     //   public char Size { get; set; }
     //   public double Price { get; set; }
     //   public bool Copyright { get; set; }
     //   public bool HighPrint { get; set; }
     //   public bool Templates { get; set; }
     //   public bool Editoral { get; set; }
     //   public string Id { get; set; }
var b = document.querySelectorAll(".var > i");
var number = 14.99;
var bool_arr = new Array(b.length).fill(true);
for (let i = 0; i < b.length; i++) {
    b[i].addEventListener("click", function () {
        bool_arr[i] = bool_arr[i] ? true : false;
        Myquery(i, bool_arr[i], 'c');
        //b[i].className = bool_arr[i] ? "ri-checkbox-line" : "ri-checkbox-blank-line";
        //switch (bool_arr[i]) {
        //    case true:
        //        switch (i) {
        //            case 0:
        //                number += 70;
        //                console.log(number);
        //                break;
        //            case 1: number += 250;
        //                break;
        //            case 2: number += 250;
        //                break;
        //            case 3: number += -3;
        //                break;
        //        }
        //        break;
        //    case false:
        //        switch (i) {
        //            case 0: number -= 70;
        //                break;
        //            case 1: number -= 250;
        //                break;
        //            case 2: number -= 250;
        //                break;
        //            case 3: number -= -3;
        //                break;
        //        }
        //        break;
        //}
        //document.querySelector(".add-to-cart p:first-of-type").innerText = "EUR" + Math.round(number * 100) / 100;
        bool_arr[i] = !bool_arr[i];
    });
}
//70 250 250 -3
var c = document.querySelector(".add-to-cart > button:first-of-type");
//c.addEventListener("click", function(){
//    document.querySelector(".add-to-cart p:first-of-type").innerHtml = "The photo was added to your <a href='#'>cart</a>";
//});

var d = document.querySelector(".add-to-cart p:first-of-type");
document.querySelector(".size button:nth-of-type(2)").style.backgroundColor = "#009ec4";
document.querySelector(".size button:nth-of-type(2)").style.color = "white";


var e = document.querySelectorAll(".size button");

for (let i = 0; i < e.length; i++) {
    e[i].addEventListener("click", function () {
        for (let j = 0; j < e.length; j++) {
            if (j == i) {
                e[j].style.backgroundColor = "#009ec4";
                e[j].style.color = "white";
                Myquery(j, false, 'b');
            }
            else {
                e[j].style.backgroundColor = "white";
                e[j].style.color = "#009ec4";
            }
        }
        var a = "1";
        //$.ajax({
        //    type: "get",
        //    url: '/Cart/GetOverlayData',
        //    data: { id: a },
        //    success: function (data) {
                
        //        var e = data.replace(/&quot;/g, '"').replace(/&#xD;/g, '\r').replace(/&#xA;/g, '\n');
        //        e = e.replace(/&#xD;/g, '\r').replace(/&#xA;/g, '\n');
        //        var json = JSON.parse(e);
        //        console.log(json);
        //        console.log(json.Price);
        //        var b = document.querySelector(".var > i");
        //        if (json.Copyright == false) {
        //            b.className = "ri-checkbox-line";
        //        }
        //        //const cleanedString = data.replace(/&quot;/g, "");
        //        //var s = cleanedString.replace(/\b(\w+)\b/g, '"$1"')
        //        //var obj = '{ "name": "Peter", "age": 22, "country": "United States" }';
        //        //{ name: 14, 99, age: 31, city:New York }

        //        //var json = JSON.parse(obj);
        //        //var json = JSON.parse(e);
        //        //console.log(e);
        //        //console.log(data);
        //        //console.log(cleanedString);
        //        //console.log(json);
        //        //console.log(json.name);
        //    }
        //});
    });
}



var element = document.querySelector(".overlay-product");
var el = document.querySelector(".overlay-product-info");
//var qo = document.querySelector(".grid-item-info > div > p").addEventListener("click", function () {
//    element.style.display = "none";
//})
element.addEventListener("mouseover", function () {
    if (element.matches(":hover") && el.matches(":hover")) {
        element.removeEventListener("click", function () { element.style.display = "block"; })
    } else {
        element.addEventListener("click", function () { element.style.display = "none"; })
    }
});