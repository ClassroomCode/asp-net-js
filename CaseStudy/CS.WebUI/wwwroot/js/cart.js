
const b = document.querySelector("#addToCartButton");
b.addEventListener("click", addToCart);

async function addToCart() {
    const q = document.querySelector("#quantity").value;
    const url = document.querySelector("#addToCartForm").getAttribute("action");

    const data = new FormData();
    data.append('quantity', q);

    const response = await fetch(url, {
        method: "POST",
        body: data
    });
    if (response.ok) {
        document.querySelector("#message").outerHTML = await response.text();
    }
}
