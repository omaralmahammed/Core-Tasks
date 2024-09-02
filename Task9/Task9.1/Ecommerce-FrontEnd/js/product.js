/** @format */

var categoryId = localStorage.getItem("categoryId");

async function getProducts() {
  let url = `https://localhost:44398/api/Products/GetProductsByCategoryId/${categoryId}`;

  let request = await fetch(url);

  let data = await request.json();
  let cardContainer = document.getElementById("product-container");

  console.log(data);

  data.forEach((product) => {
    cardContainer.innerHTML += `
        <div class="col-12 col-md-4 col-lg-3 mb-5">
            <a class="product-item" href="productDetails.html" onclick = setLocalStorage(${product.id})>
              <img
                src="/Ecommerce-BackEnd/Ecommerce-BackEnd/images/${product.imageUrl}"
                class="img-fluid product-thumbnail"
              />
              <h3 class="product-title">${product.name}</h3>
              <strong class="product-price">${product.price}$</strong>

              <span class="icon-cross ">
                <img
                  src="/Ecommerce-BackEnd/Ecommerce-BackEnd/images/cross.svg"
                  class="img-fluid"
                />
              </span>
            </a>
        </div>
      `;
  });
}

function setLocalStorage(id) {
  localStorage.productId = id;
}

getProducts();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var productId = localStorage.getItem("productId");

async function getProductDetails() {
  let url = `https://localhost:44398/api/Products/GetProductDetails/${productId}`;

  let request = await fetch(url);

  let data = await request.json();
  let cardContainer = document.getElementById("product-details");

  console.log(data);

  cardContainer.innerHTML += `
        <div class="col-lg-6 col-md-12">
          <h1 class="product-title">${data.name}</h1>
          <div class="product-reviews mb-3">
            <!-- Example stars and reviews -->
            <span class="text-warning"
              >&#9733;&#9733;&#9733;&#9733;&#9734;</span
            >
            <span>4.5 (120 Reviews)</span>
          </div>
          <h3 class="product-price">
            <strong>${data.price} $</strong>
          </h3>
          <h4 class="product-description mt-3">${data.description}</h4>
          <div class="product-purchase-options mt-4">
          <select  id="qtySelect" onchange="changeToInput()">
            <option value="1" selected>1 :Qty</option>
            <option value="2">2 :Qty</option>
            <option value="3">3 :Qty</option>
            <option value="4">4 :Qty</option>
            <option value="5">5 :Qty</option>
            <option value="6">6 :Qty</option>
            <option value="7">7 :Qty</option>
            <option value="8">8 :Qty</option>
            <option value="9">9 :Qty</option>
            <option value="10+">10+</option>
          </select>
          </div>
          <div class="product-purchase-options mt-4">
            <button class = "btn btn-secondary me-2" onclick= "addToCart()">Add to Cart</button>
          </div>

          <!-- Additional Product Info -->
          <div class="additional-info mt-5">
            <h5>Product Details</h5>
            <ul>
              <li>Material: Ceramic</li>
              <li>Dimensions: 24" H x 12" W x 12" D</li>
              <li>Weight: 10 lbs</li>
              <li>Color: White</li>
              <!-- Add more details as needed -->
            </ul>
          </div>
        </div>

        <div class="col-lg-6 col-md-12">
          <img
            src="/Ecommerce-BackEnd/Ecommerce-BackEnd/images/${data.imageUrl}"
            alt="${data.imageUrl}"
            class="img-fluid product-thumbnail w-100"
          />
        </div>
      `;
}

getProductDetails();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// replace the dropdown list with input field

function changeToInput() {
  const selectElement = document.getElementById("qtySelect");
  const selectedValue = selectElement.value;

  if (selectedValue === "10+") {
    const inputField = document.createElement("input");
    inputField.type = "number";
    inputField.id = "qtySelect";
    inputField.placeholder = "Enter quantity";

    selectElement.parentNode.replaceChild(inputField, selectElement);
  }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// add items to cart
var userId = localStorage.getItem("userId");

async function addToCart() {
  var quantity = document.getElementById("qtySelect");

  var url = `https://localhost:44398/api/Cart/addCartItem/${userId}`;
  debugger;
  fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      productId: productId,
      quantity: quantity.value,
    }),
  });

  alert("product was add to cart successfully");
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
