// Много прост вариант с fetch към The Cat API
const form = document.getElementById("form");
const countInput = document.getElementById("count");
const grid = document.getElementById("grid");
const statusBox = document.getElementById("status");
const clearBtn = document.getElementById("clear");
 
async function loadCats(n) {
  statusBox.textContent = "Зареждане...";
  grid.innerHTML = "";
 
  try {
    // Публичен API: връща масив от обекти { url: "..." }
    const res = await fetch(`https://api.thecatapi.com/v1/images/search?limit=${n}`);
    const data = await res.json();
 
    if (!Array.isArray(data) || data.length === 0) {
      statusBox.textContent = "Няма резултати. Опитай пак.";
      return;
    }
 
    data.forEach((item) => {
      const imgUrl = item.url;
      const col = document.createElement("div");
      col.className = "col-12 col-sm-6 col-md-4";
      col.innerHTML = `
<div class="card shadow-sm">
<img src="${imgUrl}" class="card-img-top" alt="Cat" loading="lazy">
<div class="card-body py-2">
<p class="card-text small mb-0">Снимка от The Cat API</p>
</div>
</div>
      `;
      grid.appendChild(col);
    });
 
    statusBox.textContent = `Заредени: ${data.length}`;
  } catch (e) {
    statusBox.textContent = "Мрежова грешка.";
  }
}
 
// Събития
form.addEventListener("submit", (e) => {
  e.preventDefault();
  const n = Math.min(Math.max(Number(countInput.value) || 1, 1), 20);
  loadCats(n);
});
 
clearBtn.addEventListener("click", () => {
  grid.innerHTML = "";
  statusBox.textContent = "";
});