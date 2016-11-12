var model  = '@Html.Raw(Json.Encode(Model.Values))';
   
  
$(document).ready(function () {
    $.ajax(
       {
           url: '/api/channel/init',
           type: 'GET',
           contentType: 'application/json',
           success: function(result) {
               for(var i=0;i<result.length;i++)
               {
                   var str="#label-"+result[i+1];
                   $(str).html(result[i]);
               }
           }
       }
       );
});
$("div.app-div").on("click",".onoff", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
             
    $.ajax(
        {
            url: '/api/channel/OnOff/'+id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(id),
            success: function(result) {
                var str="#label-"+id;
                $(str).html(result);
            }
        }
        );
}
);

$("div.app-div").on("click","button.next", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
      
    $.ajax(
            {
                url: '/api/channel/next/'+id,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(id),
                success: function(result) {
                    var str="#label-"+id;
                    $(str).html(result);
                }
            }
            );
       
}
   );


$("div.app-div").on("click","button.myprev", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
       
    $.ajax(
         {
             url: '/api/channel/prev/'+id,
             type: 'PUT',
             contentType: 'application/json',
             data: JSON.stringify(id),
             success: function(result) {
                    
                 var str="#label-"+id;
                 $(str).html(result);
             }
         }
         );
}
   );
    
$("div.app-div").on("click","button.down", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
      
    $.ajax(
        {
            url: '/api/channel/down/'+id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(id),
            success: function(result) {
                  
                var str="#label-"+id;
                $(str).html(result);
            }
        }
        );
}
  );
   
$("div.app-div").on("click","button.up", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
       
    $.ajax(
        {
            url: '/api/channel/up/'+id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(id),
            success: function(result) {
                  
                var str="#label-"+id;
                $(str).html(result);
            }
        }
        );
}
);
$("div.app-div").on("click","button.addchannel", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
    var channel=$("#textBoxAdd-"+id).val();
       
    var mydata=[];
       
    mydata[0]=id;
    mydata[1]=channel;
    $.ajax(
       {
           url: '/api/channel/addCh',
           type: 'POST',
           contentType: 'application/json',
           data: JSON.stringify(mydata),
           success: function(result) {
                   
               var str="#label-"+id;
               alert(result[0]);
               var timer=setTimeout(function(){  document.getElementById("showdiv-"+id).innerHTML=result[1];},1000);
               $("#textBoxAdd-"+id).val('');
               setTimeout(function(){ clearTimeout(timer); document.getElementById("showdiv-"+id).innerHTML="";},5000);
           }
       }
       );
}
);
$("div.app-div").on("click","button.deletech", function(e)
{
    var id=$(this).attr("id");
    e.preventDefault();
       
    $.ajax(
       {
           url: '/api/channel/deleteCh/'+id,
           type: 'DELETE',
           contentType: 'application/json',
           data: JSON.stringify(id),
           success: function(result) {
               var str="#label-"+id;
               $(str).html(result[0]);
               alert(result[1]);
               var timer=setTimeout(function(){  document.getElementById("showdiv-"+id).innerHTML=result[2];},1000);
               setTimeout(function(){ clearTimeout(timer); document.getElementById("showdiv-"+id).innerHTML="";},5000);
           }
       }
       );
}
 );
   
$("div.app-div").on("click","button.myshow", function(e)
{
    var key=$(this).attr("id");
    e.preventDefault();
       
    $.ajax(
         {
             url: '/api/channel/show/'+key,
             type: 'GET',
             contentType: 'application/json',
               
             success: function(result) {
                   
                 var timer=setTimeout(function(){  document.getElementById("showdiv-"+key).innerHTML=result;},1000);
                 setTimeout(function(){ clearTimeout(timer); document.getElementById("showdiv-"+key).innerHTML="";},5000);
                   
             }
         }
         );
       
}
);
$("div.app-div").on("click","button.deletediv", function(e)
{
    var key=$(this).attr("id");
    e.preventDefault();
                 
    $.ajax(
         {
             url: '/api/channel/deleteApp/'+key,
             type: 'DELETE',
             contentType: 'application/json',
             data: JSON.stringify(key),
             success: function(result) {
                 alert(result);
                 document.getElementById("div "+key).remove(); 
                      
             }
         }
         );
}
);