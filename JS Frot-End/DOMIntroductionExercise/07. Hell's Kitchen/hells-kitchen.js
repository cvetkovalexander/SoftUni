function solve() {
    const inputEl = document.querySelector('textarea');
    const restaurantOutput = document.querySelector('#bestRestaurant p');
    const workersOutput = document.querySelector('#workers p');

    const restaurants = JSON.parse(inputEl.value);
    let restaurantsWorkers = {};

    for (const restaurant of restaurants) {
        let [restaurantName, workersStr] = restaurant.split(' - ');
        
        if (!(restaurantName in restaurantsWorkers)) {
            restaurantsWorkers[restaurantName] = [];
        }

        let workersArr = workersStr.split(', ');
        
        for (const worker of workersArr) {
            let [name, salary] = worker.split(' ');
            salary = Number(salary);
            restaurantsWorkers[restaurantName].push({
                name,
                salary
            });
        }
    }
    
    let bestRestaurant = '';
    let bestAvgSalary = 0;

    let entries = Object.entries(restaurantsWorkers);
    
    for (const [restaurant, workers] of entries) {
        const workersSalaries = workers.map(w => w.salary);
        
        const avgSalary = workersSalaries.reduce((acc, val) => acc + val) / workersSalaries.length;

        if (avgSalary > bestAvgSalary) {
            bestRestaurant = restaurant;
            bestAvgSalary = avgSalary;
        }
    }

    let bestWorkers = restaurantsWorkers[bestRestaurant].sort((a, b) => b.salary - a.salary);
    console.log(bestWorkers);

    restaurantOutput.textContent = `Name: ${bestRestaurant} Average Salary: ${bestAvgSalary.toFixed(2)} Best Salary: ${(bestWorkers[0].salary.toFixed(2))}`;

    for (const { name, salary } of bestWorkers) {
        workersOutput.textContent += `Name: ${name} With Salary: ${salary} `;
    }
}