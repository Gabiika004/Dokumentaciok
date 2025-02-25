<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreCarRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            'license_plate_number' => 'required|string',
            'brand' => 'required|string',
            'model' => 'required|string',
            'daily_cost' => 'required|integer|min:1'
        ];
    }

    public function messages(): array
    {
        return [
            'license_plate_number' => 'A rendszám megadása kötelező (szöveg)!',
            'brand' => 'A márka megadása kötelező! (szöveg)',
            'model' => 'A modell megadása kötelező! (szöveg)',
            'daily_cost' => 'A napi árnak kötelező megadni egy pozitív egész számot!'
        ];
    }
}
