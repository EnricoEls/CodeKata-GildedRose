<img src="https://github.com/EnricoEls/CodeKata-GildedRose/blob/f39a75e24e9711aec046371710ea352c730ad30f/GildedRose/GildedRose/bannerImage.jpeg" style="width: 100%"/>

# CodeKata-GildedRose
Welcome to my solution to the GildedRose code kata. So first things first, what is the GildedRose? 
The GildedRose is a general store in the World of Warcraft universe that sells everything frome basic items and potions to legendary items and concert tickets. The GildedRose has contacted us to optimize and update their code.

## Requirements from the GildedRose
I have linked the full set of requirements [here](https://github.com/EnricoEls/CodeKata-GildedRose/blob/main/GildedRoseRequirements.md) but the basic idea is that there are:
1. We have two classes namely Item and GildedRose.
2. We can't make any changes to the Items class holding the information of the itmes, but we are allowed to make it static.
3. We need to refractor (original GildedRose class [here](https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/csharp/GildedRose.cs)) the UpdateQuality method in the GildedRose class and we are allowed to make it static, but we need to use the same method called in the original code.
4. We need to add code to handle a new item type.

Now, even though they have allowed me to change the classes to static, I have added the additional restriction that I'm not allowed to change the endpoints in any way that will require the client, or rather the goblin at the GildedRose, to make any changes other than including/replacing the files and everything should continue to work.

## The solution
In the solution here I have used the Test Driven Development (TDD) method for ensuring that the code is still working and also to add and test the additional changes from the requirements. I also decided to use more switches where it made sense as a way of showing other solutions other than simple if else solutions.

I also included a seperate branch named "AlternativeSolution" where I used a similar idea but using extention methods and making the assumption that the GildedRose is using or has access to a data source that contains a list of all legendary items. In this code I'm also utilizing that possibility as part of the code. Now, it is hard coded in the solution, but I do mention there that it will need to connect to the source.
