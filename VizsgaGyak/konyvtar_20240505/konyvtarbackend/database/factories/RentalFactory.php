<?php

namespace Database\Factories;

use App\Models\Book;
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
        $books = Book::all();
        return [
            "book_id" => fake()->randomElement($books),
            "start_date" => $this->faker->dateTimeBetween('-2 years','now'),
            "end_date" => $this->faker->dateTimeBetween('-1 years','now'),
        ];
    }
}
