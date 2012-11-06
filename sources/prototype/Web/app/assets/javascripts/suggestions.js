function UpdateCurrentVideo(id, title) {

    // un-highlight the current item
    var oldElement = document.getElementsByClassName("active");
    for(var i=0; i<oldElement.length; i++)
    {
        if(oldElement[i].id.indexOf("s")== 0)
        {
            oldElement[i].setAttribute("class", "inactive");
        }

    }

    // highlight the the new item
    var element = document.getElementById("s" + id);
    element.setAttribute("class", "active");

    // update title
    document.getElementById("tagTitle").innerText = title;


}