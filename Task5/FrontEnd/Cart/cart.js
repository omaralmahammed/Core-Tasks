/** @format */

async function getAllItems() {
  let url = "https://localhost:44333/api/Cart/getAllItemsInCart";

  let request = await fetch(url);

  let data = await request.json();
  let cardContainer = document.getElementById("table");

  console.log(data);

  data.forEach((item) => {
    cardContainer.innerHTML += `
      <tr>
          <td>${item.cartId}</td>
          <td>${item.product.productName}</td>
          <td><input id="quantity-${item.cartItemId}" type="number" placeholder="${item.quantity}" class="form-input"></td>
          <td><button type="button" onclick="updateQuantity(${item.cartItemId})">Edit</button></td>
          <td><button type="button" onclick="deleteItem(${item.cartItemId})">Delete</button></td>
      </tr>
    `;
  });
}

getAllItems();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

async function updateQuantity(CartItemID) {
  let url = `https://localhost:44333/api/Cart/updateQuantity/${CartItemID}`;

  var quantityInput = document.getElementById(`quantity-${CartItemID}`);
  var quantityValue = quantityInput.value;

  var data = {
    quantity: quantityValue,
  };

  let response = await fetch(url, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });

  location.reload();
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

async function deleteItem(CartItemID) {
  let url = `https://localhost:44333/api/Cart/deleteItemInCart/${CartItemID}`;

  fetch(url, {
    method: "DELETE",
  });

  location.reload();
}
