import sys
import WordEngineering

if __name__ == '__main__':
    dateTimeDifference = WordEngineering.DateTimeDifference(sys.argv[1], sys.argv[2])
    print(dateTimeDifference)