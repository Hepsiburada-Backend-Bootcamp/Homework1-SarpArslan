# Homework1-SarpArslan

## Features

GET,POST,PUT,DELETE

#####Listing all Animals
http://localhost:12825/api/animals (GET)

#####Ordering Animals by Filter (GET)
http://localhost:12825/api/animals/list?filter=type , example filter = type, breed

#####Sorting Animals by Filter (GET)
http://localhost:12825/api/animals/sort?filter=age , example filter = age

#####Create a new Animal
http://localhost:12825/api/animals (POST)

Body : { 
"breed":"test",
"type":"dog",
"age":12
 }

#####Updating an Animal (PUT)
 http://localhost:12825/api/animals/{id}
 
 #####Deleting an Animal (DELETE)
 http://localhost:12825/api/animals/{id}