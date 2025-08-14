function addItem() {
    const itemsEl = document.getElementById('items');
    const inputEl = document.getElementById('newItemText');
    
    const newItem = inputEl.value.trim();
    const newLinkEl = document.createElement('a');
    newLinkEl.href = '#';
    newLinkEl.textContent = '[Delete]';
    newLinkEl.addEventListener('click', handle);

    
    const newLiItem = document.createElement('li');
    newLiItem.textContent = newItem;
    newLiItem.appendChild(newLinkEl);
    
    itemsEl.appendChild(newLiItem);

    function handle() {
        newLiItem.remove();
    }
}
