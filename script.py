with open("./sudokus.txt", "+r") as file:
    file.write("".join(file.readlines()))