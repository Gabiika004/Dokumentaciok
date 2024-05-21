<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreBookRequest extends FormRequest
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
            "title" => "required",
            "author" => "required",
            "publish_year" => "required|integer",
            "page_count" => "required|integer|min:1"
        ];
    }

    public function messages(): array
    {
        return [
            "title" => "A cím megadása kötelező!",
            "author" => "A szerző megadása kötelező!",
            "publish_year" => "A kiadási év megadása kötelező (egész szám)!",
            "page_count" => "Kötelező megadni az oldalak számát (pozitív egész szám)!"
        ];
    }
}
