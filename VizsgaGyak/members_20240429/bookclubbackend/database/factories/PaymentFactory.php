<?php

namespace Database\Factories;

use App\Models\Member;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Payment>
 */
class PaymentFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        $members = Member::pluck('id')->toArray();
        return [
            
            'member_id' => $this->faker->randomElement($members),
            'amount' => $this->faker->numberBetween(1,500000),
            'paid_at' => $this->faker->dateTimeBetween('-25 years')
        ];
    }
}
