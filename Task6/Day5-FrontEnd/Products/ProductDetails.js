/** @format */

var id = localStorage.getItem("productId");

async function productDetails() {
  let request = await fetch(
    `https://localhost:44312/api/Products/getProductById/${id}`
  );

  let data = await request.json();
  let countiner = document.getElementById("countiner");

  countiner.innerHTML = `
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
            <img class="img-fluid" src="/Day5-BackEnd/Day5-BackEnd/Images/${data.productImage}" alt="${data.productName}">
            </div>
            <div class="col-md-6">
            <h1 class="display-4">${data.productName}</h1>
            <h3 class="text-muted">Price: ${data.price}</h3>
            <p class="lead">${data.description}</p>
            <!-- Add more details here -->
            <ul class="list-group">
                <li class="list-group-item"><strong>Category:</strong> ${data.categoryId}</li>
                <li class="list-group-item"><strong>price:</strong> ${data.price}</li>
            </ul>
            <div class="mt-4">
                <a href="/Day5-FrontEnd/Products/EditProduct.html" onClick="setLocalStorage(${data.productId})" class="btn btn-primary">Edit</a>
                <a href="/Day5-FrontEnd/Products/Products.html"  class="btn btn-secondary">Back to Products</a>
                <br><br>

                    <form id="addToCart">
                        <div>
                            <label>Enter Quantity:</label>
                            <input type="number" name="quantity" />
                        </div>
                        <div>
                            <button type="submit" onclick="addToCart()">Add To Cart</button>
                        </div>
                    </form>
            </div>
          </div>
        </div>
    </div>    
  
  `;
}

productDetails();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

const formRef = document.getElementById("addToCart");

function addToCart() {
  event.preventDefault();
  const formRef = document.querySelector("form");

  fetch(`https://localhost:44312/api/Cart/addCartItem`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      cartId: "1",
      productId: id,
      quantity: formRef.quantity.value,
    }),
  });
}
