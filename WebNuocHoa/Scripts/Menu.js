document.addEventListener("DOMContentLoaded", function () {
    var trangthaimenu = "tren145";
    var menu = document.querySelector('.header');

   // var divtinmoi = document.querySelector('.divtinmoi');
    //var tttinmoi = "duoi";
    //var vtritinmoi = divtinmoi.offsetTop;//lay ra vi tri cua doi tuong can lam hieu ung

    //var dodaihienthi = 600;//do dai ma divtinmoi hien thi dong bang
    //var vtctinmoi = vtritinmoi + dodaihienthi;

    //var s3 = document.querySelector('.s3');
    //var vitris3 = s3.offsetTop - 100;
    //var trangthais3 = 'chuaco';

    window.addEventListener('scroll', function () {
        var vitri = window.pageYOffset;
        console.log(vitri);

        //menu
        if (vitri > 145) {
            if (trangthaimenu == "tren145") {
                trangthaimenu = "hieuung";
                menu.classList.remove("header");
                menu.classList.add("headerfix");
            }
        } else if (vitri < 150) {
            if (trangthaimenu == "hieuung") {
                trangthaimenu = "tren145";
                menu.classList.remove("headerfix");
                menu.classList.add("header");
            }

        }
        //tinmoi
        //if ((vitri > vtritinmoi) && (vitri < vtctinmoi)) {
        //    if (tttinmoi == "duoi") {
        //        tttinmoi = "tren";
        //        divtinmoi.classList.add("tinmoitrai");
        //    }
        //}
        //else if ((vitri < vtritinmoi) || (vitri > vtctinmoi)) {
        //    if (tttinmoi == "tren") {
        //        tttinmoi = "duoi";
        //        divtinmoi.classList.remove("tinmoitrai");
        //    }
        //}

        // if(vitri>vitris3){
        // 	if (trangthais3=="chuaco") {
        // 		trangthais3='daco';
        // 		s3.classList.add('dilen');
        // 	}       	
        // }  

        //for (var i = 0; i < s3.length; i++) {
        //    var vts3 = s3[i].offsetTop;
        //    if (vitri > vitris3) {
        //        if (trangthais3 == "chuaco") {
        //            trangthais3 = 'daco';
        //            vts3.classList.add('dilen');
        //        }
        //    }
        //}
    })

}, false)