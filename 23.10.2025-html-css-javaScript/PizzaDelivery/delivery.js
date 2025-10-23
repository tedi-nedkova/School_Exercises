function calculatePrice() {
    const input_name = document.getElementById("name").value.trim();
      console.log(input_name)
    const input_email = document.getElementById("email").value.trim();
      console.log(input_email)
    const pizzaType = document.querySelector('input[name="pizzaType"]:checked')
    console.log(pizzaType)
    const size = document.getElementById("size").value;
    console.log(size)
    const quantity = parseInt(document.getElementById("quantity").value);
    console.log(quantity)
    const resultDiv = document.getElementById("result");

    const pizzaPrice = parseFloat(pizzaType.value);
    const sizePrice = parseFloat(size);
    const totalPrice = (pizzaPrice + sizePrice) * quantity;

    resultDiv.style.color = "#2c3e50";
    resultDiv.textContent = `Здравей, ${input_name}! Общата цена на поръчката е ${totalPrice} лв.`;
}
