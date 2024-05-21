<?php

namespace Database\Factories;

use App\Models\Car;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Rental>
 */
class RentalFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            "car_id" => $this->faker->randomElement(Car::pluck('id')->toArray()),
            "start_date" => $this->faker->dateTimeBetween('-2 years','now'),
            "end_date" => $this->faker->dateTimeBetween('-1 years','now'),
        ];
    }
}
