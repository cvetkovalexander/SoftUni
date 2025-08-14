function addItem() {
    const itemsEl = document.getElementById('items');
    const inputEl = document.getElementById('newItemText');
    
    const newItem = inputEl.value.trim();
    
    const newLiItem = document.createElement('li');
    newLiItem.textContent = newItem;
    
    itemsEl.append(newLiItem);
}
