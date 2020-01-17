input
with open('day2-input.txt') as f:
    input = [int(x.strip()) for x in f.read().split(',')]

input[1] = 12
input[2] = 2

for i in range(0, len(input), 4):
    if input[i] == 99:
        break;

    if input[i] == 1:
        input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]]
    if input[i] == 2:
        input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]]

print(input)
