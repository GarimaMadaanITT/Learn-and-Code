import random
 
def diceRoll(numberOfSides):

    result = random.randint(1, number_of_sides)

    return result
 
def main():

    diceSides = 6

    rolling = True

    while rolling:

        userInput = input("Ready to roll? Enter Q to Quit: ")

        if userInput.lower() != "q":

            diceResult = diceRoll(diceSides)

            print("You have rolled a", diceResult)

        else:

            rolling = False
 