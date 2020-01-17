def calculate_fuel(mass):
    fuel = int(mass / 3 - 2)
    if fuel < 0:
        return 0

    if fuel == 0:
        return fuel

    return fuel + calculate_fuel(fuel)

total = 0
with open('day1-input.txt') as f:
   for mass in f:
       fuel = calculate_fuel(int(mass))
       total += fuel
       if 'str' in mass:
          break
print(total)
