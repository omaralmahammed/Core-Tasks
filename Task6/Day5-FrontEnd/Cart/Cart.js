/** @format */

var userId = 1;

async function getUserSelectedProducts() {
  let url = `https://localhost:44312/api/Cart/getUserItems/${userId}`;

  let request = await fetch(url);

  let data = await request.json();
  let cardContainer = document.getElementById("itemsContainer");

  data.forEach((items) => {
    cardContainer.innerHTML += `
    <div class="col-md-4 mb-4">
      <div class="card">
        <img class="card-img-top" src="/Day5-BackEnd/Day5-BackEnd/Images/" alt="Card image cap 1" />
        <div class="card-body">
          <h5 class="card-title">${items.product.productName}</h5>
          <h4 class="card-title">${items.product.price}</h4>

          <p class="card-text">
           Quantity:${items.quantity}
          </p>
         
        </div>
      </div>
    </div>
      `;
  });
}

getUserSelectedProducts();
