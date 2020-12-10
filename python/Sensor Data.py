 from sense_hat import SenseHat
import time
import random
 sense = SenseHat()
def temp():

    return random.randint(20,30)

def humid():
    return random.randint(30,80)

def light():
    return random.randint(30, 150)

sense.temp = temp()
sense.humidity = humid()
sense.lightLevel = light()

print(sense.temp and sense.humidity and sense.lightLevel)
