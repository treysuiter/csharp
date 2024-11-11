\c HoneyRaes

INSERT INTO Customer (Name, Address) VALUES ('Jim Dandy', '100 Cherry St');
INSERT INTO Customer (Name, Address) VALUES ('Fred Flinstone', '20 Dinosaur Way');
INSERT INTO Customer (Name, Address) VALUES ('Barney Rubble', '35 Granite Ave');

INSERT INTO Employee (Name, Specialty) VALUES ('Roger Dodger', 'Transmissions');
INSERT INTO Employee (Name, Specialty) VALUES ('Jane Mechanic', 'Exhausts');

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (1, 1, 'Transmission slipping', FALSE, NULL);
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (2, 2, 'Needs Exhaust fixed', FALSE, NULL);
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (2, 2, 'Needs Exhaust fixed', FALSE, NULL);
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (3, NULL, 'Needs Transmissions fixed', FALSE, NULL);
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (3, NULL, 'Needs Brakes fixed', FALSE, NULL);
