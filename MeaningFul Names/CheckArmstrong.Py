def calculateArmstrongSum(number):


    armstrongSum = 0

    digitCount = 0

    temp = number

    while temp > 0:

        digit_count += 1

        temp= temp // 10

    temp = number

    for position in range(1, temp_number + 1):

        last_digit = temp_number % 10

        armstrongSum = armstrongSum + (lastigit ** digitCount)

        temp //= 10

    return armstrong_sum
 

inputNumber = int(input("\nPlease Enter the Number to Check for Armstrong: "))
 
if (inpuNumber == calculateArmstrongSum(input_number)):

    print("\n %d is an Armstrong Number.\n" % input_number)

else:

    print("\n %d is Not an Armstrong Number.\n" % input_number)
 