class CreateRefStarRatings < ActiveRecord::Migration
  def change
    create_table :ref_star_ratings do |t|

      t.float :nbr_stars
      t.timestamps
    end
  end
end
