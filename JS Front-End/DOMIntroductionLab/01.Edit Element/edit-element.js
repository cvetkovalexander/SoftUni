function editElement(htmlEl, match, replacer) {
    let elContent = htmlEl.textContent;
    
    elContent = elContent.replaceAll(match, replacer);
    htmlEl.textContent = elContent;
}