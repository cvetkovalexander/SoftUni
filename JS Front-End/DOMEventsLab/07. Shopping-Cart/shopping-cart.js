document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const bntEls = document.querySelectorAll('.add-product');
   const textareaEl = document.querySelector('textarea');
   const checkoutBtn = document.querySelector('.checkout');

   bntEls.forEach(btn => {
      btn.addEventListener('click', handleFirstEvent);
   });

   let products = new Set();
   let sum = 0;

   checkoutBtn.addEventListener('click', handleSecondEvent);

   function handleFirstEvent(e) {
      const parent = e.target.closest('.product');
      const name = parent.querySelector('.product-title').textContent;
      products.add(name);
      const money = parent.querySelector('.product-line-price').textContent;
      sum += Number(money);
      textareaEl.value += `Added ${name} for ${money} to the cart.\n`;
   }

   function handleSecondEvent() {
      const productsStr = Array.from(products).join(', ');
      textareaEl.value += `You bought ${productsStr} for ${sum.toFixed(2)}.`;
      checkoutBtn.disabled = true;

      bntEls.forEach(btn => {
         btn.disabled = true;
      });
   }
   
}
