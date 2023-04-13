const filterHandler = document.getElementById('filterHandler');
const filterForm = document.getElementById('filterForm');
const upArrow = document.getElementById('upArrow');
const downArrow = document.getElementById('downArrow');

filterHandler.addEventListener('click', function () {
    if (filterForm.style.display === 'none') {
        filterForm.style.display = 'block';
        filterForm.style.opacity = '0'; // Set the opacity to 0 to start the fade-in transition
        setTimeout(() => filterForm.style.opacity = '1', 10); // Use a short timeout to let the display change take effect before setting opacity to 1
        upArrow.style.display = 'block';
        downArrow.style.display = 'none';    
    } else {
        filterForm.style.opacity = '0'; // Set the opacity to 0 to start the fade-out transition
        setTimeout(() => filterForm.style.display = 'none', 500); // Wait for the fade-out transition to finish before setting the display to none
        upArrow.style.display = 'none';
        downArrow.style.display = 'block';    
    }
});

