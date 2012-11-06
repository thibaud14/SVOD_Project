function UpdateCurrentVideo(id) {
    var oldElement = document.getElementsByClassName("active");
    for(var i=0; i<oldElement.length; i++)
    {
        if(oldElement[i].id.indexOf("s")== 0)
        {
            oldElement[i].setAttribute("class", "inactive");
        }

    }

    var element = document.getElementById("s" + id);
    element.setAttribute("class", "active");

}