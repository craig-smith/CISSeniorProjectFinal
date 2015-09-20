$(document).ready(function(){
	$(".collapse h2").click(function(){
		$(this).parent().children().not("h2").slideToggle();
		var id = $(this).parent().attr("id");
		$("#collapseLastViewed").val(id);
	});
});

$(document).ready(function(){
	$(".collapse").children().not("h2").slideUp('fast', slideDownLastViewed);
	
});
function slideDownLastViewed(){
	var lastViewed = $("#collapseLastViewed").val();
	var elementString = "#" + lastViewed;
	$(elementString).children().not("h2").slideDown();
}
