 sense_hat = SenseHat
# import time
import random
 sense = SenseHat()


random.randint(0,9)
def temp(temp):

    return random.randint(20,30)

def humid():
    return random.randint(30,80)

def light():
    return random.randint(30, 150)

sense.temp = temp()
sense.humidity = humid()
sense.lumination = light()
