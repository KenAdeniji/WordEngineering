function Employee() {
    this.name = "";
    this.department = "general";
}

function Manager() {
    this.reports = [];
}
Manager.prototype = new Employee;

function WorkerBee() {
    this.projects = [];
}
WorkerBee.prototype = new Employee;

function SalesPerson() {
    this.dept = "Sales";
    this.quota = 100;
}
SalesPerson.prototype = new WorkerBee;

function Engineer() {
    this.dept = "Engineering";
    this.machine = "";
}
Engineer.prototype = new WorkerBee;
