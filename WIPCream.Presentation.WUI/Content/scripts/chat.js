
$(document).ready(function () {
	function refresh_chat(internal_id){
		$.ajax({
		  method: "GET",
		  url: "https://chatlog.herokuapp.com/chat_instances",
		  dataType: "JSON"
		}).done(function( msg ) {
		  json = msg;
		  custom_html = "";
		  custom_html = custom_html + "<ul class='list-group' style='margin: 0px;'>";
		  jQuery.each( json, function( i, val ) {
			if(val.foreign_id == internal_id)
			{
			  custom_html = custom_html + "<li class='list-group-item text-right'>"+ val.content+"</li>";
			}
			else
			{
			  custom_html = custom_html + "<li class='list-group-item'>"+ val.name+": "+ val.content+"</li>";
			}
		  });
		  custom_html = custom_html + "</ul>";
		  $("#chat_list").html(custom_html);
		});
	  };

	function scroll_to_end(){
		objDiv = document.getElementById("chat_list")
		objDiv.scrollTop = objDiv.scrollHeight;
	};

	function ChatInitialize(name,internal_id, height) {
    $("head").append('<style>#chat_list{height: '+height+'; overflow-y: scroll;} #chat_content{border: 1px solid #cccccc; border-radius: 4px;} .text-right{text-align: right;}</style><link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">')

    $("#chat_content").after('<i class="fa fa-coffee fa-3x togle_chat" style= "position: fixed;"></i>');
    $(".togle_chat").css({left: $(window).width() - 200,top: $(window).height() - 100});
    $("#chat_content").html('<div id="chat_list"> </div><div id="enter_name"> </div>');
    $("#chat_content").css({position: 'fixed', left: $(window).width() - 200 - 150,top: $(window).height() - 100 - parseInt(height) - 50 });

    refresh_chat(internal_id);
    setInterval(function(){ refresh_chat(internal_id);}, 3000);

    $("#enter_name").html('<form accept-charset="UTF-8" action="https://chatlog.herokuapp.com/chat_instances" class="new_chat_instance" id="new_chat_instance" method="post" data-remote="true" ><div style="margin:0;padding:0;display:inline"> <input class="form-control" id="chat_instance_content" name="chat_instance[content]" type="text"><input id="chat_instance_name" name="chat_instance[name]" type="hidden" value="'+name+'"><input id="chat_instance_foreign_id" name="chat_instance[foreign_id]" type="hidden" value="'+internal_id+'">    </form>');
    setTimeout(scroll_to_end, 100);

    $(document).on('submit','form.new_chat_instance',function(){
      refresh_chat(internal_id);
      $("#chat_instance_content").val('');
      setTimeout(scroll_to_end, 100);
    });
    $("#chat_content").toggle();
    $(document).on("click",".togle_chat",function() {
      $("#chat_content").toggle();
      setTimeout(scroll_to_end, 100);
    });



    };
	
});
	