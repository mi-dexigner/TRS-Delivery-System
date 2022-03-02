 $(document).ready(function () {
    $(".menu-dropdown:not(.submenu-active)").hover(function () {
      $(this).toggleClass("submenu-hover");
    });


     setTimeout(function () {
         $(".hideMessage").slideUp("normal", function () { $(this).remove(); });
     }, 2000);


     tinymce.init({
         selector: 'textarea[name="contents"]',
         extended_valid_elements: 'span',
         height: 500,
         menubar: false,
         inline_styles: true,
         plugins: [
             'advlist autolink lists link image charmap print preview anchor',
             'searchreplace visualblocks code fullscreen noneditable',
             'insertdatetime media table paste code'
         ],
         toolbar: ' undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | code',
     });


     function setCookie(cname, cvalue, exdays) {
         const d = new Date();
         d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
         let expires = "expires=" + d.toUTCString();
         document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
     }

     function getCookie(cname) {
         let name = cname + "=";
         let decodedCookie = decodeURIComponent(document.cookie);
         let ca = decodedCookie.split(';');
         for (let i = 0; i < ca.length; i++) {
             let c = ca[i];
             while (c.charAt(0) == ' ') {
                 c = c.substring(1);
             }
             if (c.indexOf(name) == 0) {
                 return c.substring(name.length, c.length);
             }
         }
         return "";
     }
   
   
     $('#servicesDropdown').change(function () {
         var $option = $(this).find('option:selected');
         //Added with the EDIT
         var value = $option.val();//to get content of "value" attrib
         var text = $option.text();//to get <option>Text</option> content

         setCookie("value", value, 30);
         setCookie("text", text, 30);

         if (text == "Money Order") {
             $("#weights").val(0);
         }
        
     });

     $("#weights").keydown(function () {
         let value = getCookie("value");
         let text = getCookie("text");
         var dInput = this.value;

        //alert(value);
         // alert(text);
         if (text == "Normal Post") {
             $("#cost").val(150 * dInput);
         } else if (text == "Speed Post") {
             $("#cost").val(500 * dInput);
         } else if (text == "VPP") {
             $("#cost").val(800 * dInput);
         }
     });

    


  });